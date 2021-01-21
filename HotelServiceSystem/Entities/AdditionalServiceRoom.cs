namespace HotelServiceSystem.Entities
{
	public class AdditionalServiceRoom
	{
		public int AdditionalServiceId { get; set; }
        
		public AdditionalService AdditionalService { get; set; }
        
		public int RoomId { get; set; }
        
		public Room Room { get; set; }
	}
}