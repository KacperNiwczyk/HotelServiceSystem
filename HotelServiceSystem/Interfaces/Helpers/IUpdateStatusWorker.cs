using System.Collections.Generic;
using System.Threading.Tasks;
using HotelServiceSystem.Core;
using HotelServiceSystem.Pages.Default;

namespace HotelServiceSystem.Interfaces.Helpers
{
	public interface IUpdateStatusWorker
	{
		Task UpdateReservationsStatus(HotelServiceDatabaseContext context);
	}
}