namespace MIG.API
{
    public interface INavigationService : IService
    {
        INavigationManager NavigationManager { get; }
    }
}