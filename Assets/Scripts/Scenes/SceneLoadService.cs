using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MIG.API;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MIG.SceneLoading
{
    [UsedImplicitly]
    public sealed class SceneLoadService : ISceneLoadService, ISceneLoadNotifier
    {
        private readonly SceneLoadServiceSettings _settings;
        private readonly ILogService _logger;
        private readonly ILoadingScreenService _loadingScreenService;
        private bool _isCurrentlyLoading;

        public event Action BeforeSceneLoad;
        public event Action AfterSceneLoad;

        private static CancellationToken ExitCancelToken
            => Application.exitCancellationToken;

        public SceneLoadService(
            SceneLoadServiceSettings settings,
            ILogService logger,
            ILoadingScreenService loadingScreenService
        )
        {
            _settings = settings;
            _logger = logger;
            _loadingScreenService = loadingScreenService;
        }

        public async UniTask LoadSceneAsync(string sceneName)
            => await LoadSceneAsyncInternal(GetSceneLoadTask(sceneName), GetEmulatedDelayTask());

        public async UniTask LoadSceneAsync(int sceneBuildIndex)
            => await LoadSceneAsyncInternal(GetSceneLoadTask(sceneBuildIndex), GetEmulatedDelayTask());

        public void LoadScene(string sceneName)
            => LoadSceneAsync(sceneName).Forget();

        public void LoadScene(int sceneBuildIndex)
            => LoadSceneAsync(sceneBuildIndex).Forget();

        private UniTask GetSceneLoadTask(string sceneName)
            => SceneManager.LoadSceneAsync(sceneName).ToUniTask(cancellationToken: ExitCancelToken);

        private UniTask GetSceneLoadTask(int sceneBuildIndex)
            => SceneManager.LoadSceneAsync(sceneBuildIndex).ToUniTask(cancellationToken: ExitCancelToken);

        private UniTask GetEmulatedDelayTask()
            => UniTask.Delay(TimeSpan.FromSeconds(_settings.EmulatedDelayInSeconds),
                cancellationToken: ExitCancelToken);

        private async UniTask LoadSceneAsyncInternal(params UniTask[] tasks)
        {
            if (_isCurrentlyLoading)
            {
                throw new NotSupportedException($"Multiple scene load operations aren't supported");
            }

            try
            {
                _loadingScreenService.Show();
                BeforeSceneLoad?.Invoke();
                await UniTask.WhenAll(tasks);
                AfterSceneLoad?.Invoke();
                _loadingScreenService.Hide();
            }
            catch (OperationCanceledException)
            {
                _logger.Error("Scene loading cancelled");
            }
            finally
            {
                _isCurrentlyLoading = false;
            }
        }
    }
}