using System;
using MIG.API;

namespace MIG.GameModes
{
    public interface IGameMode
    {
        void Start();
        void Stop();
        event Action<GameModeResultData> OnFinish;
    }
}