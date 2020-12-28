using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Core.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<Room> GetAllRoomsAsync()
        {
            return _roomRepository.GetAll().Include(x => x.Beds).ToList();
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            return await _roomRepository.AddAsync(room);
        }

        public Task<Room> UpdateRoomAsync(Room room)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveRoomAsync(Room room)
        {
            throw new System.NotImplementedException();
        }
    }
}