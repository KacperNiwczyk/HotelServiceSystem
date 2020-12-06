using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Repositories
{
    public class HotelReservationRepository : BaseRepository<HotelReservation>, IHotelReservationRepository
    {
        public HotelReservationRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}