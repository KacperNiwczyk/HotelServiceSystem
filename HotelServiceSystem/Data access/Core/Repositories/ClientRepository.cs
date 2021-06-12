using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Interfaces.Repositories;

namespace HotelServiceSystem.Data_access.Core.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}