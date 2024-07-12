using System;
using System.Collections.Generic;
using System.Linq;
using MIG.API;
using MIG.Extensions;

namespace MIG.GameModes
{
    public sealed class EscapeMode : IGameMode
    {
        private readonly EscapeModeSettings _settings;
        private readonly IVisibilityNotifier _visibilityNotifier;
        private readonly IVisibilityNotifyInvoker _visibilityNotifyInvoker;
        private readonly IGameActorService _gameActorService;
        private readonly ITimerService _timerService;
        private readonly ITimeService _timeService;
        private readonly ILogService _logService;
        private readonly LogChannel _logChannel = "[ESCAPE MODE]";
        private readonly IReadOnlyList<ISpawner> _banditSpawners;
        private readonly IGameActorTrigger _playerFinishTrigger;
        private readonly IEscapeModeTimerNotifyInvoker _timerNotifyInvoker;
        private readonly IUIService _uiService;

        private bool _isFinished;
        private int _timerId;
        private DateTime _startTime, _finishTime;
        private IBandit[] _bandits;

        public EscapeMode(
            EscapeModeSettings settings,
            IVisibilityNotifier visibilityNotifier,
            IVisibilityNotifyInvoker visibilityNotifyInvoker,
            IGameActorService gameActorService,
            ITimerService timerService,
            ITimeService timeService,
            ILogService logService,
            IReadOnlyList<ISpawner> banditSpawners,
            IGameActorTrigger playerFinishTrigger,
            IEscapeModeTimerNotifyInvoker timerNotifyInvoker,
            IUIService uiService
        )
        {
            _settings = settings;
            _visibilityNotifier = visibilityNotifier;
            _visibilityNotifyInvoker = visibilityNotifyInvoker;
            _gameActorService = gameActorService;
            _timerService = timerService;
            _timeService = timeService;
            _logService = logService;
            _banditSpawners = banditSpawners;
            _playerFinishTrigger = playerFinishTrigger;
            _timerNotifyInvoker = timerNotifyInvoker;
            _uiService = uiService;
        }

        public event Action<GameModeResultData> OnFinish;

        public void Start()
        {
            SpawnBandits();
            StartBanditsPatrol();
            _startTime = _timeService.Now;
            _logService.Info(_logChannel, $"Escape started at {_startTime.ToShortTimeString()}");
            StartInternal();
        }

        public void Stop()
        {
            StopInternal();
        }

        private void StartInternal()
        {
            _uiService.OpenWindow<IPlayerHUD>();
            _visibilityNotifier.OnActorObservation += OnActorObservation;
            _playerFinishTrigger.OnActorEnter += OnPlayerReachedFinish;
            _timerId = _timerService.StartTimer(_settings.FinishTimeInSeconds, OnTimeExpire);
            _timerNotifyInvoker.NotifyTimerSet(_timerId);
        }

        private void StopInternal()
        {
            _uiService.CloseWindow<IPlayerHUD>();
            _playerFinishTrigger.OnActorEnter -= OnPlayerReachedFinish;
            _visibilityNotifier.OnActorObservation -= OnActorObservation;
            _timerService.StopTimer(_timerId);
        }

        private void OnPlayerReachedFinish(IGameActor actor)
        {
            if (actor is not IPlayerCharacter) return;
            Finish(true);
        }

        private void OnTimeExpire()
        {
            Finish(false);
        }

        private void OnActorObservation(IGameActor observerActor, IReadOnlyList<IGameActor> observedActors)
        {
            var character = observedActors.FirstOrDefault(actor => actor is IPlayerCharacter);
            if (character is null) return;
            (observerActor as IBandit)?.ShootTo(character);
            Finish(false);
        }

        private void Finish(bool success)
        {
            if (_isFinished) return;

            StopInternal();

            _isFinished = true;

            _finishTime = _timeService.Now;
            _logService.Info(_logChannel, $"Escape finished at {_finishTime.ToShortTimeString()}");

            StopBanditsPatrol();
            SetCharacterReaction(success);

            OnFinish?.Invoke(new GameModeResultData
            {
                Result = success ? GameModeResultType.Success : GameModeResultType.Failure,
                ElapsedTime = _finishTime - _startTime
            });
        }

        private void SpawnBandits()
        {
            var spawnCount = Math.Min(_settings.EnemiesCount, _banditSpawners.Count);
            _bandits = new IBandit[spawnCount];

            for (var i = 0; i < spawnCount; ++i)
            {
                var spawner = _banditSpawners.PickRandomElement();
                var bandit =
                    _gameActorService.CreateActor<IBandit>(spawner.Transform.position, spawner.Transform.rotation);
                bandit.SetVisibilityNotifyInvoker(_visibilityNotifyInvoker);

                _bandits[i] = bandit;
            }
        }

        private void SetCharacterReaction(bool success)
        {
            var character = _gameActorService.GetActor<IPlayerCharacter>();
            if (success)
            {
                character.Win();
            }
            else
            {
                character.Lose();
            }
        }

        private void StartBanditsPatrol()
        {
            foreach (var bandit in _bandits)
            {
                bandit.StartPatrol();
            }
        }

        private void StopBanditsPatrol()
        {
            foreach (var bandit in _bandits)
            {
                bandit.StopPatrol();
            }
        }
    }
}