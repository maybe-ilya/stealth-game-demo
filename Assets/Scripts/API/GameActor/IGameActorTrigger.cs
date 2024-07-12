using System;

namespace MIG.API
{
    public interface IGameActorTrigger
    {
        event Action<IGameActor> OnActorEnter;
        event Action<IGameActor> OnActorExit;
    }
}