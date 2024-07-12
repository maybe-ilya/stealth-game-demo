using System.Collections.Generic;

namespace MIG.API
{
    public interface IVisibilityNotifyInvoker
    {
        void NofifyActorObservation(IGameActor observer, IReadOnlyList<IGameActor> observedActors);
    }
}