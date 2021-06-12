using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Interfaces.Services
{
    public interface IRoomService
    {
        List<Room> GetAllRoomsAsync();

        Task<List<Room>> GetAllRoomsAPI();

        Task<List<Room>> GetAvailableRooms(ReservationSpan timeSpan);
        List<Room> GetAllRoomsWithRelations(params Expression<Func<Room, object>>[] navigationProperties);
        Task<Room> GetRoomById(int id);
        Task<Room> AddRoomAsync(Room room);
        Task<Room> UpdateRoomAsync(Room room);
        Task RemoveRoomAsync(Room room);
    }
}