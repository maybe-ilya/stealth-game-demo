using MIG.API;

namespace MIG.Game.States
{
    public sealed class CancelGameState : AbstractGameState, ICancelGameState
    {
        private readonly IGameActorService _gameActorService;
        private readonly IPlayerCameraService _playerCameraService;

        public CancelGameState(
            IGameStateService gameStateService,
            IGameActorService gameActorService,
            IPlayerCameraService playerCameraService
        ) : base(gameStateService)
        {
            _gameActorService = gameActorService;
            _playerCameraService = playerCameraService;
        }

        public void Enter()
        {
            _playerCameraService.StopWatchingPlayerCharacter();
            var playerCharacter = _gameActorService.GetActor<IPlayerCharacter>();
            (playerCharacter as IPlayerPawn)?.ClearInputs();
            _gameActorService.DestroyActor(playerCharacter);
        }
    }
}