using System.Collections.Generic;
using MIG.API;

namespace MIG.GameModes
{
    public sealed class EscapeModeFactory : IGameModeFactory
    {
        private readonly EscapeModeSettings _escapeModeSettings;
        private readonly IGameActorService _gameActorService;
        private readonly ITimerService _timerService;
        private readonly ITimeService _timeService;
        private readonly ILogService _logService;
        private readonly IReadOnlyList<ISpawner> _banditSpawners;
        private readonly IGameActorTrigger _playerFinishTrigger;
        private readonly IEscapeModeTimerNotifyInvoker _escapeModeTimerNotifyInvoker;
        private readonly IUIService _uiService;

        public EscapeModeFactory(
            EscapeModeSettings escapeModeSettings,
            IGameActorService gameActorService,
            ITimerService timerService,
            ITimeService timeService,
            ILogService logService,
            IReadOnlyList<ISpawner> banditSpawners,
            IGameActorTrigger playerFinishTrigger,
            IEscapeModeTimerNotifyInvoker escapeModeTimerNotifyInvoker,
            IUIService uiService
        )
        {
            _escapeModeSettings = escapeModeSettings;
            _gameActorService = gameActorService;
            _timerService = timerService;
            _timeService = timeService;
            _logService = logService;
            _banditSpawners = banditSpawners;
            _playerFinishTrigger = playerFinishTrigger;
            _escapeModeTimerNotifyInvoker = escapeModeTimerNotifyInvoker;
            _uiService = uiService;
        }

        public IGameMode Create()
        {
            var visibilityNotifyHandler = new EscapeModeVisibilityNotifyHandler();
            var result = new EscapeMode(
                _escapeModeSettings,
                visibilityNotifyHandler,
                visibilityNotifyHandler,
                _gameActorService,
                _timerService,
                _timeService,
                _logService,
                _banditSpawners,
                _playerFinishTrigger,
                _escapeModeTimerNotifyInvoker,
                _uiService);

            return result;
        }
    }
}