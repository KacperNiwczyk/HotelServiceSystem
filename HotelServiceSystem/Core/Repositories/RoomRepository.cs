using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Core.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        private readonly IRoomHelper _roomHelper;
        public RoomRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext, IRoomHelper roomHelper) : base(hotelServiceDatabaseContext)
        {
            _roomHelper = roomHelper;
        }

        public List<Room> GetFreeRooms(TimeSpan timeSpan)
        {
            return HotelServiceDatabaseContext.Set<Room>()
                .Include(x => x.RoomReservations).AsEnumerable()
                .Where(x => _roomHelper.IsFree(x, timeSpan)).ToList();
        }
    }
}