using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MIG.API;
using MIG.Utils;
using Unity.Mathematics;
using UnityEngine.PlayerLoop;
using UnityTime = UnityEngine.Time;

namespace MIG.Time
{
    [UsedImplicitly]
    public sealed class TimerService : ITimerService
    {
        private struct TimerServiceUpdate
        {
        }

        private readonly ITimerFactory _timerFactory;

        private readonly Dictionary<int, ITimer> _runningTimers = new();
        private readonly HashSet<int> _timerIdsToExecute = new(), _timerIdsToStop = new();

        public event Action<int, float> TimerUpdated;

        public TimerService(ITimerFactory timerFactory)
        {
            _timerFactory = timerFactory;
        }

        public void Init()
        {
            new PlayerLoopSystemInjector().AddSystem<Update, TimerServiceUpdate>(UpdateTimers).Inject();
        }

        public int StartTimer(float duration, Action callback)
        {
            var newTimer = _timerFactory.Create(duration, callback);
            var timerId = newTimer.Id;
            _runningTimers[timerId] = newTimer;
            return timerId;
        }

        public void StopTimer(int timerId)
        {
            _timerIdsToStop.Add(timerId);
        }

        private void UpdateTimers()
        {
            foreach (var timerId in _timerIdsToStop)
            {
                _runningTimers.Remove(timerId);
                _timerIdsToExecute.Remove(timerId);
            }

            _timerIdsToStop.Clear();

            var deltaTime = UnityTime.deltaTime;
            foreach (var (timerId, timer) in _runningTimers)
            {
                timer.Update(deltaTime);
                TimerUpdated?.Invoke(timerId, timer.RemainingTime);

                if (timer.RemainingTime < math.EPSILON)
                {
                    _timerIdsToExecute.Add(timerId);
                }
            }

            foreach (var timerId in _timerIdsToExecute)
            {
                _runningTimers.Remove(timerId, out var timer);
                timer.Execute();
            }

            _timerIdsToExecute.Clear();
        }
    }
}