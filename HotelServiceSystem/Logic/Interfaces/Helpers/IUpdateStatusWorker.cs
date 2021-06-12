using System.Threading.Tasks;
using HotelServiceSystem.Data_access.Core;

namespace HotelServiceSystem.Logic.Interfaces.Helpers
{
	public interface IUpdateStatusWorker
	{
		Task UpdateReservationsStatus(HotelServiceDatabaseContext context);
	}
}