using MIG.API;

namespace MIG.Game.States
{
    public abstract class AbstractGameState : IGameState
    {
        protected readonly IGameStateService GameStateService;

        protected AbstractGameState(IGameStateService gameStateService)
        {
            GameStateService = gameStateService;
        }
    }
}