using System;
using MIG.API;

namespace MIG.GameModes
{
    public sealed class EscapeModeTimerHandler :
        IEscapeModeTimerNotifier,
        IEscapeModeTimerNotifyInvoker
    {
        public event Action<int> OnTimerSet;

        public void NotifyTimerSet(int timerId)
            => OnTimerSet?.Invoke(timerId);
    }
}