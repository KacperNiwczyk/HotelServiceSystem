using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Helpers;

namespace HotelServiceSystem.Core.Helpers
{
	public class ReservationHelper : IReservationHelper
	{
		public string GetClientFirstNameLastName(Client client) => $"{client.FirstName} {client.LastName}";

		public string GetRoomValues(IEnumerable<RoomReservation> roomReservation)
		{
			return string.Join(", ",roomReservation.Select(x => x.Room.RoomIdentifier));
		}

		public double GetReservationPrice(List<Room> rooms, List<AdditionalService> additionalService, int numberOfDays)
		{
			var price = 0d;
			
			if (rooms != null && rooms.Count > 0)
			{
				price += rooms.Sum(room => room.Price);
			}
			
			if (additionalService != null && additionalService.Count > 0)
			{
				price += additionalService.Sum(x => x.Price);
			}

			return price *= numberOfDays;
		}
	}
}