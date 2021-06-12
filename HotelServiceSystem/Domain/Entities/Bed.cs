using System.ComponentModel.DataAnnotations;
using HotelServiceSystem.Data_access.Core;

namespace HotelServiceSystem.Domain.Entities
{
	public class Bed
	{
		[Key]
		public int Id { get; set; }
		
		public BedType BedType { get; set; }

		public virtual Room Room { get; set; }
	}
}