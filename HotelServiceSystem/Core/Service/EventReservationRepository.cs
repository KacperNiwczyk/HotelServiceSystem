using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Service
{
    public class EventReservationService : BaseRepository<EventReservation>, IEventReservationRepository
    {
        public EventReservationService(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}