namespace MIG.API
{
    public interface INavigationManager : IService
    {
        void RequestNewTarget(INavigationAgent agent, INavigationPoint lastTarget);
        void CancelTarget(INavigationAgent agent);
    }
}