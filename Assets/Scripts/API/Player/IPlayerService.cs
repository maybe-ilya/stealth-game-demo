namespace MIG.API
{
    public interface IPlayerService : IService, IInitializableService
    {
        void ActivateInput();
        void DeactivateInput();
        IPlayerInputHandler PlayerInputHandler { get; }
    }
}