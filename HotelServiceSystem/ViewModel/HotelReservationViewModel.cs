using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Domain.Entities;
using MudBlazor;

namespace HotelServiceSystem.ViewModel
{
	public class HotelReservationViewModel : ReservationViewModel
	{
		public HotelReservationViewModel()
		{
			SelectedRooms = new List<Room>();
			SelectedAdditionalServices= new List<AdditionalService>();
		}

		public HotelReservation ToHotelReservation()
		{
			return new HotelReservation
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

		public static HotelReservationViewModel FromHotelReservation(HotelReservation reservation)
		{
			return new HotelReservationViewModel
			{
				Id = reservation.Id,
				Client = reservation.Client,
				NumberOfGuests = reservation.NumberOfGuests,
				DateRange = new DateRange(reservation.DateFrom, reservation.DateTo),
				DateOfSubmission = reservation.DateOfSubmission,
				Price = reservation.Price,
				Discount = reservation.Discount,
				HasFinished = reservation.HasFinished,
				SelectedRooms = reservation.RoomReservations.Select(x => x.Room).ToList(),
				SelectedAdditionalServices =
					reservation.AdditionalServiceReservations.Select(x => x.AdditionalService).ToList()
			};
		}
	}
}