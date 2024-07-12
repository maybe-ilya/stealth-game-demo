namespace MIG.API
{
    public interface ICameraActor : IGameActor
    {
        void StartWatchingTo(IGameActor gameActor);
        void StopWatching();
    }
}