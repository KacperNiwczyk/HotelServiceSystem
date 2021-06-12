using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Interfaces.Helpers;

namespace HotelServiceSystem.Logic.Features.Helpers
{
	public class RoomHelper : IRoomHelper
	{
		public bool IsFree(Room room, ReservationSpan reservationSpan)
		{
			foreach (var roomReservation in room.RoomReservations)
			{
				if (roomReservation?.Reservation is { } reservation)
				{
					if (reservationSpan.DateFrom.Date >= reservation.DateFrom.Date && reservationSpan.DateFrom.Date <= reservation.DateTo.Date ||   
					    reservationSpan.DateTo.Date >= reservation.DateFrom.Date && reservationSpan.DateTo.Date <= reservation.DateTo.Date )
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}