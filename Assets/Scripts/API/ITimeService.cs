using System;

namespace MIG.API
{
    public interface ITimeService : IService
    {
        DateTime Now { get; }
    }
}