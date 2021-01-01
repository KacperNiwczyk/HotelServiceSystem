using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Core.Helpers;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Services;

namespace HotelServiceSystem.Core.Service
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
			return _eventRepository.GetAll().ToList();
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