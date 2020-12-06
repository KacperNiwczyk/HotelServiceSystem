using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Service
{
    public class HotelReservationService : BaseRepository<HotelReservation>, IHotelReservationRepository
    {
        public HotelReservationService(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}