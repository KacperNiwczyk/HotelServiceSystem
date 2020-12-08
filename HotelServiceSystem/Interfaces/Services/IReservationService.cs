using System.Collections.Generic;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Services
{
	public interface IHotelReservationService
	{
		List<HotelReservation> GetAllHotelReservations();
		Task<HotelReservation> AddHotelReservationAsync(HotelReservation reservation);
		Task<HotelReservation> UpdateHotelReservationAsync(HotelReservation reservation);
		Task RemoveHotelReservationAsync(HotelReservation reservation);
	}
}