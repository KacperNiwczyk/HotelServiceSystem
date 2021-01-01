using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Services
{
	public interface IAdditionalServiceService
	{
		List<AdditionalService> GetAllAdditionalServices();

		List<AdditionalService> GetAllAdditionalServicesWithRelations(
			params Expression<Func<AdditionalService, object>>[] navigationProperties);

		Task<AdditionalService> AddAdditionalServiceAsync(AdditionalService service);

		Task<AdditionalService> UpdateAdditionalServiceAsync(AdditionalService service);

		Task RemoveAdditionalService(AdditionalService service);
	}
}