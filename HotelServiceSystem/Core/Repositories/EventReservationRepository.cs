using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Repositories
{
    public class EventReservationRepository : BaseRepository<EventReservation>, IEventReservationRepository
    {
        public EventReservationRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}