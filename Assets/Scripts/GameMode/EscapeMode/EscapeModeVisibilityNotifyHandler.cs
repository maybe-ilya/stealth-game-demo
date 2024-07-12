using System;
using System.Collections.Generic;
using MIG.API;

namespace MIG.GameModes
{
    public sealed class EscapeModeVisibilityNotifyHandler :
        IVisibilityNotifier,
        IVisibilityNotifyInvoker
    {
        public event Action<IGameActor, IReadOnlyList<IGameActor>> OnActorObservation;

        public void NofifyActorObservation(IGameActor observer, IReadOnlyList<IGameActor> observedActors)
            => OnActorObservation?.Invoke(observer, observedActors);
    }
}