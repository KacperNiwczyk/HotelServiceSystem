using System.Collections.Generic;
using System.Threading.Tasks;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Interfaces.Helpers;
using HotelServiceSystem.Logic.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Data_access.Core.Repositories
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

        public async Task<List<Room>> GetApiRoomsAsync()
        {
            return await HotelServiceDatabaseContext.Set<Room>()
                .Include(x => x.Beds)
                .Include(x => x.AdditionalServiceRooms)
                .ThenInclude(x => x.AdditionalService)
                .ToListAsync();
        }
    }
}