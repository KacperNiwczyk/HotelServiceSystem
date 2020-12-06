using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Service
{
    public class RoomService : BaseRepository<Room>, IRoomRepository
    {
        public RoomService(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }

        public Task<ICollection<Room>> GetFreeRooms(TimeSpan timeSpan)
        {
            throw new System.NotImplementedException();
        }
    }
}