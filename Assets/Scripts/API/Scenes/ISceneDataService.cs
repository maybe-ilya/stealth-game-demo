namespace MIG.API
{
    public interface ISceneDataService : IService
    {
        int CurrentSceneIndex { get; }
        string CurrentSceneName { get; }
    }
}