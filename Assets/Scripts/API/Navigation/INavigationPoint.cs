using UnityEngine;

namespace MIG.API
{
    public interface INavigationPoint
    {
        int Id { get; }
        Vector3 Position { get; }
    }
}