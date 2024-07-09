using System;
using UnityEngine;

namespace MIG.Main
{
    public sealed class GameInstance
    {
        private readonly IAppScope _appScope;
        private readonly ISceneScopeFactory _sceneScopeFactory;
        private ISceneScope _sceneScope;

        public static GameInstance Value { get; private set; }

        private GameInstance(IAppScope appScope)
        {
            _appScope = appScope;
            _sceneScopeFactory = new SceneScopeFactory(_appScope,
                new MainMenuScopeFactory(_appScope),
                new PlayGameScopeFactory(_appScope));
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void InitializeGameInstance()
        {
            if (Value is not null)
            {
                throw new Exception($"{nameof(GameInstance)} is already initialized");
            }

            Value = new GameInstance(new AppScopeFactory().Create());
            Value.Launch();
        }

        private void Launch()
        {
            _appScope.SceneLoadNotifier.BeforeSceneLoad += OnBeforeSceneLoad;
            _appScope.SceneLoadNotifier.AfterSceneLoad += OnAfterSceneLoad;
            _appScope.Activate();
        }

        private void OnBeforeSceneLoad()
        {
            _sceneScope?.Deactivate();
            _sceneScope = null;
        }

        private void OnAfterSceneLoad()
        {
            _sceneScope = _sceneScopeFactory.Create();
            _sceneScope.Activate();
        }
    }
}