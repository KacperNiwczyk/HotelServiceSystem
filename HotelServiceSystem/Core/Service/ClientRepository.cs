using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Service
{
    public class ClientService : BaseRepository<Client>, IClientRepository
    {
        public ClientService(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }
    }
}