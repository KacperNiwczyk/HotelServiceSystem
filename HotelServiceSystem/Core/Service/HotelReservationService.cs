using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Core.Helpers;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Repositories;
using HotelServiceSystem.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Core.Service
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

		public HotelReservation GetById(int id)
		{
			return _hotelReservationRepository.GetAll().Include(x => x.AdditionalServiceReservations).FirstOrDefault(x => x.Id == id);
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