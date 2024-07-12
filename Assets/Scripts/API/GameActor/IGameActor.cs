using UnityEngine;

namespace MIG.API
{
    public interface IGameActor
    {
        int Id { get; }
        Transform Transform { get; }
    }
}