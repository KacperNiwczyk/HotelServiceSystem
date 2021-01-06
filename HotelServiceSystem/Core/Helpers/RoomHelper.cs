using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Helpers;

namespace HotelServiceSystem.Core.Helpers
{
	public class RoomHelper : IRoomHelper
	{
		public bool IsFree(Room room, TimeSpan timeSpan)
		{
			foreach (var roomReservation in room.RoomReservations)
			{
				if (roomReservation?.Reservation is Reservation reservation)
				{
					if (timeSpan.DateFrom.Date >= reservation.DateFrom.Date && timeSpan.DateFrom.Date <= reservation.DateTo.Date ||   
					    timeSpan.DateTo.Date >= reservation.DateFrom.Date && timeSpan.DateTo.Date <= reservation.DateTo.Date )
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}