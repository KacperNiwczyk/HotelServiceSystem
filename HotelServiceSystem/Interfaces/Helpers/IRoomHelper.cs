using HotelServiceSystem.Core;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Helpers
{
	public interface IRoomHelper
	{
		bool IsFree(Room room, HssTimeSpan hssTimeSpan);

		void UpdateStatus(Room room);
	}
}