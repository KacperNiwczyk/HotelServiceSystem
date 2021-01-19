using System.Collections.Generic;

namespace HotelServiceSystem.Entities
{
	public class ReservationAdditional : AdditionalService
	{
		public ICollection<AdditionalServiceReservation> AdditionalServiceReservations { get; set; }

		public ReservationAdditional()
		{
			AdditionalServiceReservations = new HashSet<AdditionalServiceReservation>();
		}
	}
}