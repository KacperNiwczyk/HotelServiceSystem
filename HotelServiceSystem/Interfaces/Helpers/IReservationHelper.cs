using System.Collections.Generic;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Helpers
{
	public interface IReservationHelper
	{ 
		string GetClientFirstNameLastName(Client client);

		string GetRoomValues(IEnumerable<RoomReservation> roomReservation);
	}
}