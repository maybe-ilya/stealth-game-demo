namespace MIG.API
{
    public interface IPlayerService : IService, IInitializableService
    {
        void SetGameplayInputMode();
        void SetUIInputMode();
        IPlayerInputHandler PlayerInputHandler { get; }
    }
}