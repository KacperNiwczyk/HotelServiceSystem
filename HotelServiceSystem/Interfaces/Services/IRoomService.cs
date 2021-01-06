using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;
using TimeSpan = HotelServiceSystem.Core.TimeSpan;

namespace HotelServiceSystem.Interfaces.Services
{
    public interface IRoomService
    {
        List<Room> GetAllRoomsAsync();

        List<Room> GetAvailableRooms(TimeSpan timeSpan);
        List<Room> GetAllRoomsWithRelations(params Expression<Func<Room, object>>[] navigationProperties);
        Room GetRoomById(int id);
        Task<Room> AddRoomAsync(Room room);
        Task<Room> UpdateRoomAsync(Room room);
        Task RemoveRoomAsync(Room room);
    }
}