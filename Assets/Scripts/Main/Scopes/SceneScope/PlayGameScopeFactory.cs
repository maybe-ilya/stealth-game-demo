using MIG.Game;
using MIG.StateMachine;

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
            var gameStateMachine = new StateMachine<IGameState>();
            var gameStateService = new GameStateService(gameStateMachine);

            return new PlayGameScope(gameStateService);
        }
    }
}