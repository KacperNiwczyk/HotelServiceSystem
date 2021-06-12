using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Interfaces.Repositories;

namespace HotelServiceSystem.Data_access.Core.Repositories
{
	public class AdditionalServiceRepository : BaseRepository<AdditionalService>, IAdditionalServiceRepository
	{
		public AdditionalServiceRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
		{
		}
	}
}