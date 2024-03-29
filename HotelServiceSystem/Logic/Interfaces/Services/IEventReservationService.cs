﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Interfaces.Services
{
	public interface IEventReservationService
	{
		List<EventReservation> GetAllEvents();

		EventReservation GetById(int id);
		List<EventReservation> GetAllEventsWithRelations(
			params Expression<Func<EventReservation, object>>[] navigationProperties);

		Task<EventReservation> AddEventAsync(EventReservation eventReservation);

		Task<EventReservation> UpdateEventAsync(EventReservation eventReservation);

		Task RemoveEventAsync(EventReservation eventReservation);
	}
}