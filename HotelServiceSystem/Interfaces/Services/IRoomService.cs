using System.Collections.Generic;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Services
{
    public interface IRoomService
    {
        List<Room> GetAllRoomsAsync();
        Task<Room> AddRoomAsync(Room room);
        Task<Room> UpdateRoomAsync(Room room);
        Task RemoveRoomAsync(Room room);
    }
}