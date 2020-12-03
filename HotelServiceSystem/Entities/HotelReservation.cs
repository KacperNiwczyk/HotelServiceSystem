using System.Collections.Generic;

namespace HotelServiceSystem.Entities
{
    public class HotelReservation : Reservation
    {
        public ICollection<RoomReservation> RoomReservations { get; set; }
    }
}