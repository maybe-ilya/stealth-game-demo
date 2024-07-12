using System;
using UnityEngine;
using MIG.API;

namespace MIG.GameActors
{
    public interface IGameActorFactory :
        IFactory<IGameActor, int>,
        IFactory<IGameActor, int, Vector3>,
        IFactory<IGameActor, int, Vector3, Quaternion>
    {
        Type ActorType { get; }
    }
}