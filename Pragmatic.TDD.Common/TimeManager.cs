using System;
using Pragmatic.TDD.Common.Interfaces;

namespace Pragmatic.TDD.Common
{
    public class TimeManager : ITimeManager
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}