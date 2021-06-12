using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Interfaces.Repositories;

namespace HotelServiceSystem.Data_access.Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}