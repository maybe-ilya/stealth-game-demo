using System;

namespace MIG.Main
{
    public sealed class SceneScopeFactory : ISceneScopeFactory
    {
        private const int MAIN_MENU_SCENE_INDEX = 1;
        private const int PLAY_GAME_SCENE_INDEX = 2;

        private readonly IAppScope _appScope;
        private readonly ISceneScopeFactory _mainMenuScopeFactory, _playGameScopeFactory;

        public SceneScopeFactory(
            IAppScope appScope,
            ISceneScopeFactory mainMenuScopeFactory,
            ISceneScopeFactory playGameScopeFactory
        )
        {
            _appScope = appScope;
            _mainMenuScopeFactory = mainMenuScopeFactory;
            _playGameScopeFactory = playGameScopeFactory;
        }

        public ISceneScope Create()
        {
            switch (_appScope.SceneDataService.CurrentSceneIndex)
            {
                case MAIN_MENU_SCENE_INDEX:
                    return _mainMenuScopeFactory.Create();

                case PLAY_GAME_SCENE_INDEX:
                    return _playGameScopeFactory.Create();
                
                default:
                    throw new ArgumentException($"No scene scope factory for {_appScope.SceneDataService.CurrentSceneName}");
            }
        }
    }
}