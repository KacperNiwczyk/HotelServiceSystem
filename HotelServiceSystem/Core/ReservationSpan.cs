using System;

namespace HotelServiceSystem.Core
{
    public readonly struct ReservationSpan
    {
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }

        public ReservationSpan(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public int GetAmountOfDays()
        {
            return (int) (DateTo - DateFrom).TotalDays;
        }
    }
}