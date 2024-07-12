using MIG.API;

namespace MIG.Navigation
{
    public sealed class NavigationService :
        INavigationService,
        INavigationManagerUpdater
    {
        public INavigationManager NavigationManager { get; private set; }

        public void Update(INavigationManager newNavigationManager)
            => NavigationManager = newNavigationManager;
    }
}