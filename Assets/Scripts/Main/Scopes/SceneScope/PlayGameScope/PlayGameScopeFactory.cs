using System;
using MIG.Camera;
using MIG.Game;
using MIG.Game.States;
using MIG.GameModes;
using MIG.StateMachine;
using UObject = UnityEngine.Object;

namespace MIG.Main
{
    public class PlayGameScopeFactory : ISceneScopeFactory
    {
        private readonly IAppScope _appScope;

        public PlayGameScopeFactory(IAppScope appScope)
        {
            _appScope = appScope;
        }

        public ISceneScope Create()
        {
            var dependencies = UObject.FindObjectOfType<PlayGameScopeDependencies>(true);
            if (dependencies is null)
            {
                throw new ArgumentException($"{nameof(PlayGameScopeDependencies)} not found");
            }

            var gameStateMachine = new StateMachine<IGameState>();
            var gameStateService = new GameStateService(gameStateMachine);
            var playerCameraService = new PlayerCameraService(_appScope.GameActorService);

            var escapeModeFactory = new EscapeModeFactory(
                dependencies.EscapeModeSettings,
                _appScope.GameActorService,
                _appScope.TimerService,
                _appScope.TimeService,
                _appScope.LogService,
                dependencies.BanditSpawners,
                dependencies.PlayerFinishTrigger,
                _appScope.EscapeModeTimerNotifyInvoker,
                _appScope.UIService);
            var gameModeService = new GameModeService(escapeModeFactory);

            gameStateMachine.AddState<IStartGameState>(
                new StartGameState(gameStateService,
                    _appScope.GameActorService,
                    dependencies.PlayerStart,
                    playerCameraService,
                    gameModeService));

            gameStateMachine.AddState<IPlayGameState>(
                new PlayGameState(
                    gameStateService,
                    _appScope.PlayerService,
                    gameModeService));

            gameStateMachine.AddState<IFinishGameState>(
                new FinishGameState(gameStateService,
                    playerCameraService,
                    _appScope.PlayerService,
                    _appScope.UIService));

            gameStateMachine.AddState<ICancelGameState>(
                new CancelGameState(gameStateService,
                    _appScope.GameActorService,
                    playerCameraService));

            return new PlayGameScope(
                gameStateService,
                _appScope.NavigationManagerUpdater,
                dependencies.NavigationManager);
        }
    }
}