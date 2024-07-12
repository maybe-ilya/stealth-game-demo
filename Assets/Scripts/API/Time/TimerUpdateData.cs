using System;

namespace MIG.API
{
    public struct TimerUpdateData
    {
        public readonly int TimerId;
        public readonly bool IsTriggered;
        public readonly float RemainingTime;
        public readonly TimeSpan RemainingTimeSpan;
        public readonly float Ratio;

        public TimerUpdateData(
            int timerId,
            bool isTriggered,
            float remainingTime,
            TimeSpan remainingTimeSpan,
            float ratio)
        {
            TimerId = timerId;
            IsTriggered = isTriggered;
            RemainingTime = remainingTime;
            RemainingTimeSpan = remainingTimeSpan;
            Ratio = ratio;
        }
    }
}