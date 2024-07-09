using Cysharp.Threading.Tasks;
using MIG.API;

namespace MIG.App.States
{
    public sealed class MainMenuAppState : IMainMenuAppState
    {
        private readonly MainMenuAppStateSettings _settings;
        private readonly ISceneLoadService _sceneLoader;
        private readonly ILogService _logger;
        private readonly IPlayerService _playerService;
        private readonly IUIService _uiService;

        public MainMenuAppState(
            MainMenuAppStateSettings settings,
            ISceneLoadService sceneLoader,
            ILogService logger,
            IPlayerService playerService,
            IUIService uiService
        )
        {
            _settings = settings;
            _sceneLoader = sceneLoader;
            _logger = logger;
            _playerService = playerService;
            _uiService = uiService;
        }

        public void Enter()
            => EnterAsync().Forget();

        private async UniTaskVoid EnterAsync()
        {
            _logger.Info("Going to main menu");
            await _sceneLoader.LoadSceneAsync(_settings.MainMenuSceneIndex);
            _uiService.OpenWindow<IMainMenuWindow>();
            _playerService.SetUIInputMode();
        }
    }
}