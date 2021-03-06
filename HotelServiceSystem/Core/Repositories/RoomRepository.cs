using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Room>> GetFreeRooms(ReservationSpan reservationSpan)
        {
            return await  HotelServiceDatabaseContext.Set<Room>()
                .Include(x => x.RoomReservations).ToListAsync();
        }
    }
}