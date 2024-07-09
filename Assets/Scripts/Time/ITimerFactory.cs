using System;
using MIG.API;

namespace MIG.Time
{
    public interface ITimerFactory : IFactory<ITimer, float, Action>
    {
    }
}