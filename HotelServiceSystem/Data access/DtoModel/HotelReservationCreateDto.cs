using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Features.Helpers;
using HotelServiceSystem.Logic.Interfaces.Services;

namespace HotelServiceSystem.Data_access.DtoModel
{
	public class HotelReservationCreateDto
	{
		public ClientDto ClientDto { get; set; }

		public int NumberOfGuests { get; set; }
        
		public string DateFrom { get; set; }
		
		public string DateTo { get; set; }

		public ICollection<int> RoomsIds { get; set; }
        
		public ICollection<int> AdditionalServiceIds { get; set; }

		public HotelReservationCreateDto()
		{
			ClientDto = new ClientDto();
			RoomsIds = new List<int>();
			AdditionalServiceIds = new List<int>();
		}

		public async Task<HotelReservation> To(IRoomService roomService, IAdditionalServiceService additionalServiceService)
		{
			var reservation = new HotelReservation();
			var helper = new ReservationHelper();
			
			reservation.Client = new Client
			{
				FirstName = ClientDto.FirstName,
				LastName = ClientDto.LastName,
				PhoneNumber = ClientDto.PhoneNumber,
				Email = ClientDto.Email
			};

			reservation.NumberOfGuests = NumberOfGuests;

			reservation.DateFrom = ParseDate(DateFrom);
			reservation.DateTo = ParseDate(DateTo);

			reservation.RoomReservations = new List<RoomReservation>();
			var selectedRoom = await GetSelectedRoomList(roomService);
			var selectedAdditionalServices = GetSelectedAdditionalServices(additionalServiceService);
			AddRoomsToReservation(selectedRoom, reservation);
			AddAdditionalServicesToReservation(selectedAdditionalServices, reservation);

			var numberOfDays = (int)(reservation.DateTo - reservation.DateFrom).TotalDays;
			reservation.Price = helper.GetReservationPrice(selectedRoom, selectedAdditionalServices, numberOfDays);
			
			return reservation;
		}

		private async Task<List<Room>> GetSelectedRoomList(IRoomService roomService)
		{
			var list = new List<Room>();
			foreach (var id in RoomsIds)
			{
				var room = await roomService.GetRoomById(id);
				list.Add(room);
			}

			return list;
		}

		private List<AdditionalService> GetSelectedAdditionalServices(IAdditionalServiceService service)
		{
			var list = new List<AdditionalService>();
			
			foreach (var id in AdditionalServiceIds)
			{
				list.Add(service.GetById(id));
			}

			return list;
		}

		private void AddRoomsToReservation(List<Room> selectedRooms, HotelReservation reservation)
		{
			foreach (var room in selectedRooms)
			{
				var roomReservation = new RoomReservation()
				{
					Room = room,
					Reservation = reservation,
				};
				
				reservation.RoomReservations.Add(roomReservation);
			}
		}

		private void AddAdditionalServicesToReservation(List<AdditionalService> additionalServices,
			HotelReservation reservation)
		{
			foreach (var additionalService in additionalServices)
			{
				if (additionalService == null)
				{
					continue;
				}
				
				var additionalServiceReservation = new AdditionalServiceReservation()
				{
					AdditionalService = additionalService,
					Reservation = reservation,
				};
				
				reservation.AdditionalServiceReservations.Add(additionalServiceReservation);
			}
		}

		private DateTime ParseDate(string date)
		{
			return DateTime.TryParseExact(date, Constants.DefaultDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result) ? result : DateTime.Now;
		}
	}
}