using JetBrains.Annotations;
using MIG.API;
using MIG.Utils;
using UnityEditor;

namespace MIG.App.States
{
    [UsedImplicitly]
    public sealed class QuitAppState : IQuitAppState
    {
        private readonly ILogService _logService;

        public QuitAppState(ILogService logService)
        {
            _logService = logService;
        }

        public void Enter()
            => QuitApp();

        private void QuitApp()
        {
            _logService.Info("Quitting game. Bye bye!");
#if UNITY_EDITOR
            PlayerLoopUtils.ResetPlayerLoopSystems();
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}