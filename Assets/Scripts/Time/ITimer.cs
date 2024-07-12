using System;

namespace MIG.Time
{
    public interface ITimer
    {
        int Id { get; }
        float Duration { get; }
        float RemainingTime { get; }
        float Ratio { get; }
        DateTime ExpireTime { get; }
        TimeSpan RemainingTimeSpan { get; }
        void Update(float deltaTime);
        void Execute();
    }
}