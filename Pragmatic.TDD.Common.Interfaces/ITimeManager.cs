using System;

namespace Pragmatic.TDD.Common.Interfaces
{
    public interface ITimeManager
    {
        DateTime UtcNow { get; }
    }
}
