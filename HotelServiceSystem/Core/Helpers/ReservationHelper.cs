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
	}
}