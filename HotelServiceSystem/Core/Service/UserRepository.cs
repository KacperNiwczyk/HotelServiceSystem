using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Service
{
    public class UserService : BaseRepository<User>, IUserRepository
    {
        public UserService(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}