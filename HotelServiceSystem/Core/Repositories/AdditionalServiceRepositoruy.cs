using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Repositories
{
	public class AdditionalServiceRepository : BaseRepository<AdditionalService>, IAdditionalServiceRepository
	{
		public AdditionalServiceRepository(HotelServiceDatabaseContext hotelServiceDatabaseContext) : base(hotelServiceDatabaseContext)
		{
		}
	}
}