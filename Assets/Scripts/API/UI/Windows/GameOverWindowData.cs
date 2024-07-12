using System;

namespace MIG.API
{
    public struct GameOverWindowData : IWindowData
    {
        public readonly bool IsSuccessful;
        public readonly TimeSpan ElapsedTime;

        public GameOverWindowData(bool isSuccessful, TimeSpan elapsedTime)
        {
            IsSuccessful = isSuccessful;
            ElapsedTime = elapsedTime;
        }
    }
}