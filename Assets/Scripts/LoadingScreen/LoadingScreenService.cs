using JetBrains.Annotations;
using MIG.API;

namespace MIG.LoadingScreen
{
    [UsedImplicitly]
    public sealed class LoadingScreenService : ILoadingScreenService
    {
        private readonly ILoadingScreenFactory _loadingScreenFactory;
        private ILoadingScreen _loadingScreen;

        public LoadingScreenService(ILoadingScreenFactory loadingScreenFactory)
        {
            _loadingScreenFactory = loadingScreenFactory;
        }

        public void Init()
        {
            _loadingScreen = _loadingScreenFactory.Create();
            _loadingScreen.Hide();
        }

        public void Show()
            => _loadingScreen.Show();

        public void Hide()
            => _loadingScreen.Hide();
    }
}