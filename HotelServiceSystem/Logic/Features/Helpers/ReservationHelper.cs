using System;
using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Interfaces.Helpers;

namespace HotelServiceSystem.Logic.Features.Helpers
{
	public class ReservationHelper : IReservationHelper
	{
		public string GetClientFirstNameLastName(Client client) => $"{client.FirstName} {client.LastName}";

		public string GetRoomValues(IEnumerable<RoomReservation> roomReservation)
		{
			return string.Join(", ",roomReservation.Select(x => x.Room.RoomIdentifier));
		}

		public double GetReservationPrice(List<Room> rooms, List<AdditionalService> additionalService, int numberOfDays, int discount = 0)
		{
			var price = 0d;
			
			if (rooms != null && rooms.Count > 0)
			{
				price += rooms.Sum(room => room.Price);
			}
			
			if (additionalService != null && additionalService.Count > 0)
			{
				price += additionalService.Where(x => x != null).Sum(x => x.Price);
			}

			if (discount != 0)
			{
				var discountValue = (double)Math.Round(discount / 100m, 2);
				var totalPrice = price * numberOfDays;
				var discountTotal = totalPrice * discountValue;
				return totalPrice - discountTotal;
			}

			return price * numberOfDays;
		}
	}
}