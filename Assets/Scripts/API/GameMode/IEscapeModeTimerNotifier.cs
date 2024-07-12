using System;

namespace MIG.API
{
    public interface IEscapeModeTimerNotifier
    {
        event Action<int> OnTimerSet;
    }
}