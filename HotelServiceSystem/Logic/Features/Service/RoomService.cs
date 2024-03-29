﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Features.Helpers;
using HotelServiceSystem.Logic.Interfaces.Repositories;
using HotelServiceSystem.Logic.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Logic.Features.Service
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

        public async Task<List<Room>> GetAllRoomsAPI()
        {
            return await _roomRepository.GetApiRoomsAsync();
        }

        public async Task<List<Room>> GetAvailableRooms(ReservationSpan reservationSpan)
        {
            return await _roomRepository.GetFreeRooms(reservationSpan);
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _roomRepository.GetAll()
                .Include(x => x.Beds)
                .Include(x => x.AdditionalServiceRooms)
                .ThenInclude(x => x.AdditionalService)
                .Include(x => x.RoomReservations)
                .ThenInclude(x => x.Reservation)
                .ThenInclude(x => x.Client)
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