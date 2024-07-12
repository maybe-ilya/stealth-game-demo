using MIG.API;

namespace MIG.Main
{
    public sealed class PlayGameScope : ISceneScope
    {
        private readonly IGameStateService _gameStateService;
        private readonly INavigationManagerUpdater _navigationManagerUpdater;
        private readonly INavigationManager _navigationManager;

        public PlayGameScope(
            IGameStateService gameStateService,
            INavigationManagerUpdater navigationManagerUpdater,
            INavigationManager navigationManager
        )
        {
            _gameStateService = gameStateService;
            _navigationManagerUpdater = navigationManagerUpdater;
            _navigationManager = navigationManager;
        }

        public void Activate()
        {
            _navigationManagerUpdater.Update(_navigationManager);
            _gameStateService.Start();
        }

        public void Deactivate()
        {
            _gameStateService.Cancel();
        }
    }
}