using MIG.API;

namespace MIG.Main
{
    public interface IAppScope : IScope
    {
        IAppStateService AppStateService { get; }
        ISceneLoadService SceneLoadService { get; }
        ISceneLoadNotifier SceneLoadNotifier { get; }
        ISceneDataService SceneDataService { get; }
        ILogService LogService { get; }
        IFileService FileService { get; }
        IPlayerService PlayerService { get; }
        ITimeService TimeService { get; }
        ITimerService TimerService { get; }
        IUIService UIService { get; }
        ILoadingScreenService LoadingScreenService { get; }
    }
}