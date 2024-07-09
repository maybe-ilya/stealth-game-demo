using System;
using UnityEngine;

namespace MIG.API
{
    public interface IPlayerInputHandler
    {
        event Action<Vector2> OnMove;
    }
}