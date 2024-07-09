using MIG.API;

namespace MIG.Main
{
    public sealed class PlayGameScope : ISceneScope
    {
        private readonly IGameStateService _gameStateService;

        public PlayGameScope(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
        }

        public void Activate()
        {
            _gameStateService.Start();
        }

        public void Deactivate()
        {
            _gameStateService.Finish(); //  TODO: add proper deinitialization state
        }
    }
}