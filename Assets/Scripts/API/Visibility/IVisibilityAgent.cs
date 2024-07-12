namespace MIG.API
{
    public interface IVisibilityAgent
    {
        bool IsVisible { get; }
        IGameActor Actor { get; }
    }
}