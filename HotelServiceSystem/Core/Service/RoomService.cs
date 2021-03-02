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
            return _roomRepository.GetAll().Include(x => x.Beds)
                .Include(x => x.AdditionalServiceRooms)
                .ThenInclude(x => x.AdditionalService)
                .Include(x => x.RoomReservations)
                .ThenInclude(x => x.Reservation)
                .ToList();
        }

        public List<Room> GetAvailableRooms(ReservationSpan reservationSpan)
        {
            return _roomRepository.GetFreeRooms(reservationSpan);
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _roomRepository.GetAll()
                .Include(x => x.Beds)
                .Include(x => x.AdditionalServiceRooms)
                .ThenInclude(x => x.AdditionalService)
                .Include(x => x.RoomReservations)
                .ThenInclude(x => x.Reservation)
                .FirstOrDefaultAsync(x => x.Id == id);
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