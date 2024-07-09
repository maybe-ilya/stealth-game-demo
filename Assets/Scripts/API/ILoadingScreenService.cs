namespace MIG.API
{
    public interface ILoadingScreenService : IService, IInitializableService
    {
        void Show();
        void Hide();
    }
}