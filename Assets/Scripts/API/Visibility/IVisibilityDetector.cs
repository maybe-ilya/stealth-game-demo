using System;
using System.Collections.Generic;

namespace MIG.API
{
    public interface IVisibilityDetector
    {
        event Action<IReadOnlyList<IGameActor>> OnDetectActors;
    }
}