namespace HotelServiceSystem.Domain.Entities
{
    public class AdditionalServiceReservation
    {
        public int AdditionalServiceId { get; set; }
        
        public AdditionalService AdditionalService { get; set; }
        
        public int ReservationId { get; set; }
        
        public Reservation Reservation { get; set; }
    }
}