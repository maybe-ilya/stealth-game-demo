using MIG.API;

namespace MIG.Main
{
    public sealed class AppScope : IAppScope
    {
        public IAppStateService AppStateService { get; }
        public ISceneLoadService SceneLoadService { get; }
        public ISceneLoadNotifier SceneLoadNotifier { get; }
        public ISceneDataService SceneDataService { get; }
        public ILogService LogService { get; }
        public IFileService FileService { get; }
        public IPlayerService PlayerService { get; }
        public ITimeService TimeService { get; }
        public ITimerService TimerService { get; }
        public IUIService UIService { get; }
        public ILoadingScreenService LoadingScreenService { get; }
        public IGameActorService GameActorService { get; }
        public INavigationManagerUpdater NavigationManagerUpdater { get; }
        public IEscapeModeTimerNotifyInvoker EscapeModeTimerNotifyInvoker { get; }

        public AppScope(
            IAppStateService appStateService,
            ISceneLoadService sceneLoadService,
            ISceneLoadNotifier sceneLoadNotifier,
            ISceneDataService sceneDataService,
            ILogService logService,
            IFileService fileService,
            IPlayerService playerService,
            ITimeService timeService,
            ITimerService timerService,
            IUIService uiService,
            ILoadingScreenService loadingScreenService,
            IGameActorService gameActorService,
            INavigationManagerUpdater navigationManagerUpdater,
            IEscapeModeTimerNotifyInvoker escapeModeTimerNotifyInvoker
        )
        {
            AppStateService = appStateService;
            SceneLoadService = sceneLoadService;
            SceneLoadNotifier = sceneLoadNotifier;
            SceneDataService = sceneDataService;
            LogService = logService;
            FileService = fileService;
            PlayerService = playerService;
            TimeService = timeService;
            TimerService = timerService;
            UIService = uiService;
            LoadingScreenService = loadingScreenService;
            GameActorService = gameActorService;
            NavigationManagerUpdater = navigationManagerUpdater;
            EscapeModeTimerNotifyInvoker = escapeModeTimerNotifyInvoker;
        }

        public void Activate()
        {
            InitializeServices();
            AppStateService.GoToMainMenu();
        }

        public void Deactivate()
        {
        }

        private void InitializeServices()
        {
            var initializableServices = new IInitializableService[]
            {
                TimerService,
                UIService,
                LoadingScreenService,
                PlayerService
            };

            foreach (var service in initializableServices)
            {
                service.Init();
            }
        }
    }
}