using System;
using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Helpers;

namespace HotelServiceSystem.Core.Helpers
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