using MIG.API;

namespace MIG.Camera
{
    public sealed class PlayerCameraService : IPlayerCameraService
    {
        private readonly IGameActorService _gameActorService;
        private ICameraActor _playerCamera;

        public PlayerCameraService(IGameActorService gameActorService)
        {
            _gameActorService = gameActorService;
        }

        public void StartWatchingPlayerCharacter(IPlayerCharacter playerCharacter)
        {
            _playerCamera = _gameActorService.CreateActor<ICameraActor>();
            _playerCamera.StartWatchingTo(playerCharacter);
        }

        public void StopWatchingPlayerCharacter()
        {
            _playerCamera.StopWatching();
        }
    }
}