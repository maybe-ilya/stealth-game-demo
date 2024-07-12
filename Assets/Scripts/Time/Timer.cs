using System;
using MIG.API;
using Unity.Mathematics;

namespace MIG.Time
{
    internal sealed class Timer : ITimer
    {
        public int Id { get; }
        public float Duration { get; }
        public float RemainingTime { get; private set; }
        public float Ratio => RemainingTime / Duration;
        public DateTime ExpireTime { get; }
        public TimeSpan RemainingTimeSpan => ExpireTime - _timeService.Now;

        private readonly ITimeService _timeService;
        private readonly Action _callback;

        public Timer(int id, float duration, Action callback, ITimeService timeService)
        {
            Id = id;
            Duration = duration;
            RemainingTime = duration;
            _callback = callback;
            _timeService = timeService;
            ExpireTime = _timeService.Now + TimeSpan.FromSeconds(duration);
        }

        public void Update(float deltaTime)
            => RemainingTime = math.max(RemainingTime - deltaTime, 0.0f);

        public void Execute()
            => _callback?.Invoke();
    }
}