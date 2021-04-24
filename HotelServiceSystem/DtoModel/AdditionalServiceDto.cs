using HotelServiceSystem.Entities;

namespace HotelServiceSystem.DtoModel
{
	public class AdditionalServiceDto
	{
		
		public int Id { get; set; }
		public string Name { get; set; }
		
		public double Price { get; set; }

		public static AdditionalServiceDto From(AdditionalService additionalService)
		{
			return new AdditionalServiceDto()
			{
				Id = additionalService.Id,
				Name = additionalService.Name,
				Price = additionalService.Price
			};
		}
	}
}