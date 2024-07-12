namespace MIG.API
{
    public interface INavigationAgent
    {
        IGameActor Actor { get; }
        void SetTarget(INavigationPoint newTarget);
        void OnReachPoint(INavigationPoint reachedPoint);
    }
}