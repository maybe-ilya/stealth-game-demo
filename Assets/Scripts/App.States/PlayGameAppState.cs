using Cysharp.Threading.Tasks;
using MIG.API;

namespace MIG.App.States
{
    public sealed class PlayGameAppState : IPlayGameAppState
    {
        private readonly PlayGameAppStateSettings _settings;
        private readonly ISceneLoadService _sceneLoader;
        private readonly ILogService _logger;

        public PlayGameAppState(
            PlayGameAppStateSettings settings,
            ISceneLoadService sceneLoader,
            ILogService logger
        )
        {
            _settings = settings;
            _sceneLoader = sceneLoader;
            _logger = logger;
        }

        public void Enter()
            => EnterAsync().Forget();

        private async UniTaskVoid EnterAsync()
        {
            _logger.Info("Going to play game");
            await _sceneLoader.LoadSceneAsync(_settings.PlayGameSceneIndex);
        }
    }
}