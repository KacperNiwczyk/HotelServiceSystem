using System.Collections.Generic;

namespace HotelServiceSystem.Entities
{
	public class RoomAdditional : AdditionalService
	{
		public ICollection<AdditionalServiceRoom> AdditionalRoomServiceReservations { get; set; }

		public RoomAdditional()
		{
			AdditionalRoomServiceReservations = new HashSet<AdditionalServiceRoom>();
		}
	}
}