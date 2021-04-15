using App.Services;
using System;

namespace Infrastructures.Persistence
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now() => DateTime.Now;
    }
}
