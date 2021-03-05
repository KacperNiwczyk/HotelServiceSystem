using System;
using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.ViewModel
{
	public class HotelReservationViewModel
	{
	
		public int Id { get; set; }
        
		public Client Client { get; set; }
        
		public int NumberOfGuests { get; set; }
        
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
        
		public double Price { get; set; }
        
		public DateTime DateOfSubmission { get; set; }
        
		public double Discount { get; set; }
        
		public bool HasFinished { get; set; }
        
		public List<Room> SelectedRooms { get; set; }
        
		public List<AdditionalService> SelectedAdditionalServices { get; set; }

		public HotelReservationViewModel()
		{
			SelectedRooms = new List<Room>();
			SelectedAdditionalServices= new List<AdditionalService>();
		}

		public HotelReservation ToHotelReservation(HotelReservation reference = null)
		{
			if (reference != null)
			{
				reference.Client = Client;
				reference.NumberOfGuests = NumberOfGuests;
				reference.DateFrom = DateFrom;
				reference.DateTo = DateTo;
				reference.Price = Price;
				reference.DateOfSubmission = DateOfSubmission;
				reference.Discount = Discount;
				reference.HasFinished = HasFinished;
				reference.RoomReservations = ParseRoomReservations();
				reference.AdditionalServiceReservations = ParseAdditionalServiceReservations();
				return reference;
			}
			
			return new HotelReservation
			{
				Id = Id,
				Client = Client,
				NumberOfGuests = NumberOfGuests,
				DateFrom = DateFrom,
				DateTo = DateTo,
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
				DateFrom = reservation.DateFrom,
				DateTo = reservation.DateTo,
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