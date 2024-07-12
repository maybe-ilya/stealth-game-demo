namespace MIG.API
{
    public interface INavigationManagerUpdater : IService
    {
        void Update(INavigationManager newNavigationManager);
    }
}