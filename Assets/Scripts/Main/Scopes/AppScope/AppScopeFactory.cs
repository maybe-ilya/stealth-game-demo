using System;
using MIG.App;
using MIG.App.States;
using MIG.Files;
using MIG.LoadingScreen;
using MIG.Logging;
using MIG.Player;
using MIG.Player.Impl;
using MIG.SceneLoading;
using MIG.StateMachine;
using MIG.Time;
using MIG.UI;
using MIG.UI.Windows;
using MIG.Utils;
using UObject = UnityEngine.Object;

namespace MIG.Main
{
    public sealed class AppScopeFactory : IAppScopeFactory
    {
        public IAppScope Create()
        {
            var dependencies = UObject.FindObjectOfType<AppScopeDependencies>(true);
            if (dependencies is null)
            {
                throw new Exception("Initialize game from bootstrap scene");
            }

            var logService = new UnityLogService();
            var fileService = new FileService();

            var loadingScreenService =
                new LoadingScreenService(new LoadingScreenFactory(dependencies.LoadingScreenFactorySettings));

            var sceneLoadService =
                new SceneLoadService(dependencies.LoadServiceSettings, logService, loadingScreenService);

            var sceneDataService = new SceneDataService();
            var timeService = new TimeService();
            var timerService = new TimerService(new TimerFactory(timeService));

            var appStateMachine = new StateMachine<IAppState>();
            var appStateService = new AppStateService(appStateMachine);

            IMultiModePlayerInputHandlerFactory playerInputHandlerFactory =
                new DefaultInputHandlerFactory(dependencies.DefaultInputHandlerFactorySettings);

            if (ApplicationUtils.IsMobile)
            {
                playerInputHandlerFactory = new MobileInputHandlerFactory(playerInputHandlerFactory,
                    new MobileInputUIPanelFactory(dependencies.InputUIPanelFactorySettings));
            }

            var localPlayerFactory = new LocalPlayerFactory(playerInputHandlerFactory);
            var playerService = new PlayerService(localPlayerFactory);

            var windowControllers = new IWindowController[]
            {
                new MainMenuWindowController(appStateService)
            };

            var windowFactories = new IWindowFactory[]
            {
                new MainMenuWindowFactory(dependencies.MainMenuWindowFactorySettings)
            };

            var windowHandler = new WindowHandler(sceneLoadService, dependencies.WindowHandlerSettings,
                windowControllers, windowFactories);
            var uiService = new UIService(windowHandler);

            appStateMachine.AddState<IMainMenuAppState>(new MainMenuAppState(dependencies.MenuAppStateSettings,
                sceneLoadService, logService, playerService, uiService));
            appStateMachine.AddState<IPlayGameAppState>(new PlayGameAppState(dependencies.PlayGameAppStateSettings,
                sceneLoadService, logService));
            appStateMachine.AddState<IQuitAppState>(new QuitAppState(logService));

            return new AppScope(
                appStateService,
                sceneLoadService,
                sceneLoadService,
                sceneDataService,
                logService,
                fileService,
                playerService,
                timeService,
                timerService,
                uiService,
                loadingScreenService
            );
        }
    }
}