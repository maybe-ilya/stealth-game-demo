using MIG.API;

namespace MIG.Game.States
{
    public sealed class FinishGameState :
        AbstractGameState,
        IFinishGameState,
        IExitableState
    {
        private readonly IPlayerService _playerService;
        private readonly IPlayerCameraService _playerCameraService;
        private readonly IUIService _uiService;

        private int _gameOverWindowId;

        public FinishGameState(
            IGameStateService gameStateService,
            IPlayerCameraService playerCameraService,
            IPlayerService playerService,
            IUIService uiService
        ) : base(gameStateService)
        {
            _playerCameraService = playerCameraService;
            _playerService = playerService;
            _uiService = uiService;
        }

        public void Enter(GameModeResultData resultData)
        {
            _playerService.DeactivateInput();
            _playerCameraService.StopWatchingPlayerCharacter();
            _gameOverWindowId = _uiService.OpenWindow<IGameOverWindow, GameOverWindowData>(
                new GameOverWindowData(resultData.Result == GameModeResultType.Success, resultData.ElapsedTime));
        }

        public void Exit()
        {
            _uiService.CloseWindow(_gameOverWindowId);
        }
    }
}