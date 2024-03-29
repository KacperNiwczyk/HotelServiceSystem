﻿using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Domain.Entities;
using MudBlazor;

namespace HotelServiceSystem.ViewModel
{
	public class EventReservationViewModel : ReservationViewModel
	{
		public string Description { get; set; }
		
		public EventReservationViewModel()
		{
			SelectedRooms = new List<Room>();
			SelectedAdditionalServices= new List<AdditionalService>();
		}

		public EventReservation ToEventReservation()
		{
			return new EventReservation
			{
				Id = Id,
				Client = Client,
				NumberOfGuests = NumberOfGuests,
				DateFrom = DateRange.Start.Value,
				DateTo = DateRange.End.Value,
				Price = Price,
				DateOfSubmission = DateOfSubmission,
				Discount = Discount,
				HasFinished = HasFinished,
				Description = Description,
				RoomReservations = ParseRoomReservations(),
				AdditionalServiceReservations = ParseAdditionalServiceReservations()
			};
		}
		
		private ICollection<AdditionalServiceReservation> ParseAdditionalServiceReservations()
		{
			return SelectedAdditionalServices
				.Select(addService => new AdditionalServiceReservation {AdditionalService = addService}).ToList();
		}

		private ICollection<RoomReservation> ParseRoomReservations()
		{
			return SelectedRooms.Select(selectedRoom => new RoomReservation {Room = selectedRoom}).ToList();
		}

		public static EventReservationViewModel FromEventReservation(EventReservation reservation)
		{
			return new EventReservationViewModel
			{
				Id = reservation.Id,
				Client = reservation.Client,
				NumberOfGuests = reservation.NumberOfGuests,
				DateRange = new DateRange(reservation.DateFrom, reservation.DateTo),
				DateOfSubmission = reservation.DateOfSubmission,
				Price = reservation.Price,
				Discount = reservation.Discount,
				HasFinished = reservation.HasFinished,
				Description = reservation.Description,
				SelectedRooms = reservation.RoomReservations.Select(x => x.Room).ToList(),
				SelectedAdditionalServices =
					reservation.AdditionalServiceReservations.Select(x => x.AdditionalService).ToList()
			};
		}
	}
}