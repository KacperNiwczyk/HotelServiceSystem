using System;
using System.Text.Json.Serialization;

namespace HotelServiceSystem.Data_access.Core
{
    public readonly struct ReservationSpan
    {
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DateFrom { get; }
        
        [JsonConverter(typeof(CustomDateTimeConverter))]
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