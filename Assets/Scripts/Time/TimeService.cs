using System;
using JetBrains.Annotations;
using MIG.API;

namespace MIG.Time
{
    [UsedImplicitly]
    public sealed class TimeService : ITimeService
    {
        public DateTime Now => DateTime.Now;
    }
}