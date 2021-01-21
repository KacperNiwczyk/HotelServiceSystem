﻿namespace HotelServiceSystem.Entities
{
    public class RoomReservation
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}