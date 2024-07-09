namespace MIG.Main
{
    public sealed class MainMenuScopeFactory : ISceneScopeFactory
    {
        private readonly IAppScope _appScope;

        public MainMenuScopeFactory(IAppScope appScope)
        {
            _appScope = appScope;
        }

        public ISceneScope Create()
            => new MainMenuScope(_appScope.LogService);
    }
}