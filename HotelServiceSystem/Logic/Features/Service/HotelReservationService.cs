﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Features.Helpers;
using HotelServiceSystem.Logic.Interfaces.Repositories;
using HotelServiceSystem.Logic.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Logic.Features.Service
{
	public class HotelReservationService : IHotelReservationService
	{
		private readonly IHotelReservationRepository _hotelReservationRepository;
		
		public HotelReservationService(IHotelReservationRepository hotelRepository)
		{
			_hotelReservationRepository = hotelRepository;
		}

		public List<HotelReservation> GetAllHotelReservations(Func<HotelReservation, bool> filter = null)
		{
			if (filter != null)
			{
				return _hotelReservationRepository.GetAll()
					.Include(x => x.RoomReservations)
					.ThenInclude(x => x.Room)
					.Include(x => x.Client)
					.AsEnumerable()
					.Where(filter)
					.ToList();
			}

			return _hotelReservationRepository.GetAll()
				.Include(x => x.RoomReservations)
				.ThenInclude(x => x.Room)
				.Include(x => x.Client)
				.ToList();
		}

		public async Task<HotelReservation> GetById(int id)
		{
			return await _hotelReservationRepository.GetSetAsync().Result
				.Include(x => x.AdditionalServiceReservations)
				.ThenInclude(x => x.AdditionalService)
				.Include(x => x.Client)
				.Include(x => x.RoomReservations)
				.ThenInclude(x => x.Room)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public List<HotelReservation> GetAllWithRelations(params Expression<Func<HotelReservation, object>>[] navigationProperties)
		{
			return _hotelReservationRepository.GetAll().IncludeMultiple(navigationProperties).ToList();
		}

		public async Task<HotelReservation> AddHotelReservationAsync(HotelReservation reservation)
		{
			return await _hotelReservationRepository.AddAsync(reservation);
		}

		public async Task<HotelReservation> UpdateHotelReservationAsync(HotelReservation reservation)
		{
			return await _hotelReservationRepository.UpdateAsync(reservation);
		}

		public async Task RemoveHotelReservationAsync(HotelReservation reservation)
		{
			await _hotelReservationRepository.DeleteAsync(reservation);
		}
	}
}