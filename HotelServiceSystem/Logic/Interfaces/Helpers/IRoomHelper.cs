using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Interfaces.Helpers
{
	public interface IRoomHelper
	{
		bool IsFree(Room room, ReservationSpan reservationSpan);
	}
}