using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Interfaces.Repositories;

namespace HotelServiceSystem.Data_access.Core.Repositories
{
    public class EventReservationRepository : BaseRepository<EventReservation>, IEventReservationRepository
    {
        public EventReservationRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}