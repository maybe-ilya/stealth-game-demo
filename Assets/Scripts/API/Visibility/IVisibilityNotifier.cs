using System;
using System.Collections.Generic;

namespace MIG.API
{
    public interface IVisibilityNotifier
    {
        event Action<IGameActor, IReadOnlyList<IGameActor>> OnActorObservation;
    }
}