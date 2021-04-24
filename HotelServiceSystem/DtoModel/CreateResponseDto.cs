namespace HotelServiceSystem.DtoModel
{
	public class CreateResponseDto
	{
		public string Status { get; set; }
		
		public double Price { get; set; }
		
		public string ReservationId { get; set; }
		
		public string[] Errors { get; set; }
	}
}