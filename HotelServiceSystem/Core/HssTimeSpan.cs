using System;

namespace HotelServiceSystem.Core
{
    public readonly struct HssTimeSpan
    {
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }

        public HssTimeSpan(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}