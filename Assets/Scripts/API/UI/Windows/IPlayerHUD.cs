using System;

namespace MIG.API
{
    public interface IPlayerHUD : IWindow
    {
        void SetTimerRatio(float ratio);
        void SetTimerText(string timerText);
        event Action OnReplayClicked;
    }
}