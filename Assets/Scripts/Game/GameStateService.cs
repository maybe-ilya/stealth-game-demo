using JetBrains.Annotations;
using MIG.API;

namespace MIG.Game
{
    [UsedImplicitly]
    public sealed class GameStateService : IGameStateService
    {
        private readonly IStateMachine<IGameState> _stateMachine;

        public GameStateService(IStateMachine<IGameState> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Start()
            => _stateMachine.ChangeState<IStartGameState>();

        public void Play()
            => _stateMachine.ChangeState<IPlayGameState>();

        public void Finish(GameModeResultData resultData)
            => _stateMachine.ChangeState<IFinishGameState, GameModeResultData>(resultData);

        public void Cancel()
            => _stateMachine.ChangeState<ICancelGameState>();
    }
}