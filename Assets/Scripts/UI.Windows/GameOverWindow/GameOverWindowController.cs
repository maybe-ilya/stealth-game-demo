using MIG.API;

namespace MIG.UI.Windows
{
    public sealed class GameOverWindowController : AbstractWindowController<IGameOverWindow>
    {
        private readonly IAppStateService _appStateService;

        public GameOverWindowController(IAppStateService appStateService)
        {
            _appStateService = appStateService;
        }

        protected override void OnWindowSet()
        {
            Window.OnRetryClicked += OnRetryClicked;
            Window.OnExitClicked += OnExitClicked;
        }

        protected override void BeforeWindowClear()
        {
            Window.OnRetryClicked -= OnRetryClicked;
            Window.OnExitClicked -= OnExitClicked;
        }

        private void OnRetryClicked()
        {
            _appStateService.PlayGame();
        }

        private void OnExitClicked()
        {
            _appStateService.GoToMainMenu();
        }
    }
}