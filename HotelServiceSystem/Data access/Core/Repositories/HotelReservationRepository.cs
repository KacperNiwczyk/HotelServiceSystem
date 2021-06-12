using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Interfaces.Repositories;

namespace HotelServiceSystem.Data_access.Core.Repositories
{
    public class HotelReservationRepository : BaseRepository<HotelReservation>, IHotelReservationRepository
    {
        public HotelReservationRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}