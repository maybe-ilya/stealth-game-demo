using System;

namespace MIG.API
{
    public interface IGameModeService : IService
    {
        void Setup();
        void Start();
        void Stop();
        event Action<GameModeResultData> OnFinish;
    }
}