using MIG.API;

namespace MIG.UI.Windows
{
    public sealed class PlayerHUDController : AbstractWindowController<IPlayerHUD>
    {
        private readonly IEscapeModeTimerNotifier _escapeModeTimerNotifier;
        private readonly ITimerService _timerService;
        private readonly IAppStateService _appStateService;
        private int _timerId;

        public PlayerHUDController(
            IEscapeModeTimerNotifier escapeModeTimerNotifier,
            ITimerService timerService,
            IAppStateService appStateService
        )
        {
            _timerService = timerService;
            _appStateService = appStateService;
            _escapeModeTimerNotifier = escapeModeTimerNotifier;
            _escapeModeTimerNotifier.OnTimerSet += OnTimerStarted;
        }

        private void OnTimerStarted(int timerId)
            => _timerId = timerId;

        protected override void OnWindowSet()
        {
            Subscribe();
        }

        protected override void BeforeWindowClear()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _timerService.OnTimerUpdated += OnTimerUpdated;
            _timerService.OnTimerStopped += OnTimerStopped;
            Window.OnReplayClicked += OnReplayClicked;
        }

        private void Unsubscribe()
        {
            Window.OnReplayClicked -= OnReplayClicked;
            _timerService.OnTimerUpdated -= OnTimerUpdated;
            _timerService.OnTimerStopped -= OnTimerStopped;
        }

        private void OnTimerUpdated(TimerUpdateData data)
        {
            if (data.TimerId != _timerId) return;
            Window.SetTimerRatio(data.Ratio);
            Window.SetTimerText(data.RemainingTimeSpan.TotalSeconds.ToString("F1"));
        }

        private void OnTimerStopped(int timerId)
        {
            if (timerId != _timerId) return;
            Unsubscribe();
        }

        private void OnReplayClicked()
            => _appStateService.PlayGame();
    }
}