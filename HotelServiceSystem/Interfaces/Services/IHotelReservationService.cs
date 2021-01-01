﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Services
{
	public interface IHotelReservationService
	{
		List<HotelReservation> GetAllHotelReservations();

		List<HotelReservation> GetAllWithRelations(
			params Expression<Func<HotelReservation, object>>[] navigationProperties);
		Task<HotelReservation> AddHotelReservationAsync(HotelReservation reservation);
		Task<HotelReservation> UpdateHotelReservationAsync(HotelReservation reservation);
		Task RemoveHotelReservationAsync(HotelReservation reservation);
	}
}