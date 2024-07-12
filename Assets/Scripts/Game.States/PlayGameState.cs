using MIG.API;

namespace MIG.Game.States
{
    public sealed class PlayGameState :
        AbstractGameState,
        IPlayGameState,
        IExitableState
    {
        private readonly IPlayerService _playerService;
        private readonly IGameModeService _gameModeService;

        public PlayGameState(
            IGameStateService gameStateService,
            IPlayerService playerService,
            IGameModeService gameModeService
        ) : base(gameStateService)
        {
            _playerService = playerService;
            _gameModeService = gameModeService;
        }

        public void Enter()
        {
            _playerService.ActivateInput();
            _gameModeService.OnFinish += OnGameModeFinish;
            _gameModeService.Start();
        }

        private void OnGameModeFinish(GameModeResultData resultData)
            => GameStateService.Finish(resultData);

        public void Exit()
        {
            _gameModeService.OnFinish -= OnGameModeFinish;
            _gameModeService.Stop();
        }
    }
}