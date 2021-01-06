using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Core.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
        {
        }

        public List<Room> GetFreeRooms(TimeSpan timeSpan)
        {
            return HotelServiceDatabaseContext.Set<Room>()
                .Include(x => x.RoomReservations)
                .Where(x => x.IsFree(timeSpan)).ToList();
        }
    }
}