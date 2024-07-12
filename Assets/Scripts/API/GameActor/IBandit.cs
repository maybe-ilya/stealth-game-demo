namespace MIG.API
{
    public interface IBandit : IGameActor
    {
        void SetVisibilityNotifyInvoker(IVisibilityNotifyInvoker notifyInvoker);
        void StartPatrol();
        void StopPatrol();
        void ShootTo(IGameActor gameActor);
    }
}