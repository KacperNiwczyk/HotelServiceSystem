using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Data_access.DtoModel
{
	public class RoomDto
	{
		public int Id { get; set; }
        
		public string RoomIdentifier { get; set; }
		
		public int SingleBeds { get; set; }
		
		public int DoubleBeds { get; set; }
		public int Floor { get; set; }
        
		public double Price { get; set; }

		public ICollection<string> AdditionalServices { get; set; }


		public static RoomDto From(Room room)
		{
			return new RoomDto()
			{
				Id = room.Id,
				RoomIdentifier = room.RoomIdentifier,
				SingleBeds = room.Beds.Where(x => x.BedType == BedType.SingleBed).Count(),
				DoubleBeds = room.Beds.Where(x => x.BedType == BedType.DoubleBed).Count(),
				Floor = room.Floor,
				Price = room.Price,
				AdditionalServices = room.AdditionalServiceRooms.Select(x => x.AdditionalService.Name).ToList()
			};
		}
	}
}