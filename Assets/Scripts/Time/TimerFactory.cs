using System;
using JetBrains.Annotations;
using MIG.API;

namespace MIG.Time
{
    [UsedImplicitly]
    public sealed class TimerFactory : ITimerFactory
    {
        private readonly ITimeService _timeService;
        private int _createdTimersCounter;

        public TimerFactory(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public ITimer Create(float duration, Action callback)
            => new Timer(_createdTimersCounter++, duration, callback, _timeService);
    }
}