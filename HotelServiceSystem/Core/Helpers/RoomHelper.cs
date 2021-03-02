using System;
using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Helpers;

namespace HotelServiceSystem.Core.Helpers
{
	public class RoomHelper : IRoomHelper
	{
		public bool IsFree(Room room, HssTimeSpan hssTimeSpan)
		{
			foreach (var roomReservation in room.RoomReservations)
			{
				if (roomReservation?.Reservation is Reservation reservation)
				{
					if (hssTimeSpan.DateFrom.Date >= reservation.DateFrom.Date && hssTimeSpan.DateFrom.Date <= reservation.DateTo.Date ||   
					    hssTimeSpan.DateTo.Date >= reservation.DateFrom.Date && hssTimeSpan.DateTo.Date <= reservation.DateTo.Date )
					{
						return false;
					}
				}
			}

			return true;
		}

		public void UpdateStatus(Room room)
		{
			if (room?.RoomReservations != null)
			{
				var roomReservations = room.RoomReservations;
				var localTime = DateTime.Today;
				var futureReservations = roomReservations.Where(x => x?.Reservation?.DateFrom >= localTime)
					.Select(x => x.Reservation)
					.ToArray();

				if (futureReservations.Length == 0)
				{
					return;
				}
				
				if (room.IsFreeNow)
				{
					if (futureReservations.Any(x => x.DateFrom <= localTime && x.DateTo >= localTime))
					{
						room.IsFreeNow = false;
					}
				}

				if (!room.ShouldBeCleaned)
				{
					if (futureReservations.Any(x => x.DateTo <= localTime))
					{
						room.ShouldBeCleaned = true;
						room.IsFreeNow = true;
					}
				}
			}
		}
	}
}