using MIG.API;

namespace MIG.Game.States
{
    public sealed class StartGameState : AbstractGameState, IStartGameState
    {
        private readonly IGameActorService _gameActorService;
        private readonly IPlayerStart _playerStart;
        private readonly IPlayerCameraService _playerCameraService;
        private readonly IGameModeService _gameModeService;

        public StartGameState(
            IGameStateService gameStateService,
            IGameActorService gameActorService,
            IPlayerStart playerStart,
            IPlayerCameraService playerCameraService,
            IGameModeService gameModeService
        ) : base(gameStateService)
        {
            _gameActorService = gameActorService;
            _playerStart = playerStart;
            _playerCameraService = playerCameraService;
            _gameModeService = gameModeService;
        }

        public void Enter()
        {
            var playerStartTransform = _playerStart.Transform;
            var playerCharacter = _gameActorService.CreateActor<IPlayerCharacter>(
                playerStartTransform.position,
                playerStartTransform.rotation);
            _playerCameraService.StartWatchingPlayerCharacter(playerCharacter);

            _gameModeService.Setup();

            GameStateService.Play();
        }
    }
}