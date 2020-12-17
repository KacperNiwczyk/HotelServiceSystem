using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Core;

namespace HotelServiceSystem.Entities
{
	public class Bed
	{
		[Key]
		public int Id { get; set; }
		
		public BedType BedType { get; set; }

		public virtual Room Room { get; set; }
	}
}