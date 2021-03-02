using HotelServiceSystem.Core;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Helpers
{
	public interface IRoomHelper
	{
		bool IsFree(Room room, ReservationSpan reservationSpan);
	}
}