using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Core.Helpers;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
            return _roomRepository.GetAll().ToList();
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            return await _roomRepository.AddAsync(room);
        }

        public async Task<Room> UpdateRoomAsync(Room room)
        {
            return await _roomRepository.UpdateAsync(room);
        }

        public async Task RemoveRoomAsync(Room room)
        {
            await _roomRepository.DeleteAsync(room);
        }

        public List<Room> GetAllRoomsWithRelations(params Expression<Func<Room, object>>[] navigationProperties)
        {
            return _roomRepository.GetAll().IncludeMultiple(navigationProperties).ToList();
        }
    }
}