using System;
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
	public class EventReservationService : IEventReservationService
	{
		private readonly IEventReservationRepository _eventRepository;

		public EventReservationService(IEventReservationRepository eventRepository)
		{
			_eventRepository = eventRepository;
		}
		
		public List<EventReservation> GetAllEvents()
		{
			return _eventRepository.GetAll()
				.Include(x => x.Client)
				.Include(x => x.RoomReservations)
				.ThenInclude(x => x.Room)
				.ToList();
		}

		public EventReservation GetById(int id)
		{
			return _eventRepository.GetById(id);
		}

		public List<EventReservation> GetAllEventsWithRelations(
			params Expression<Func<EventReservation, object>>[] navigationProperties)
		{
			return _eventRepository.GetAll().IncludeMultiple(navigationProperties).ToList();
		}

		public async Task<EventReservation> AddEventAsync(EventReservation eventReservation)
		{
			return await _eventRepository.AddAsync(eventReservation);
		}

		public async Task<EventReservation> UpdateEventAsync(EventReservation eventReservation)
		{
			return await _eventRepository.UpdateAsync(eventReservation);
		}
		
		public async Task RemoveEventAsync(EventReservation eventReservation)
		{
			await _eventRepository.DeleteAsync(eventReservation);
		}
	}
}