using System;

namespace HotelServiceSystem.Core
{
    public readonly struct TimeSpan
    {
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }

        public TimeSpan(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}