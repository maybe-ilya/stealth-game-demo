namespace MIG.API
{
    public interface IPlayerCameraService : IService
    {
        void StartWatchingPlayerCharacter(IPlayerCharacter playerCharacter);
        void StopWatchingPlayerCharacter();
    }
}