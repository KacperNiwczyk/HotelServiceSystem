using System.Collections.Generic;

namespace HotelServiceSystem.Entities
{
    public class AdditionalServiceReservation
    {
        public int AdditionalServiceId { get; set; }
        
        public ReservationAdditional AdditionalService { get; set; }
        
        public int ReservationId { get; set; }
        
        public Reservation Reservation { get; set; }
    }
}