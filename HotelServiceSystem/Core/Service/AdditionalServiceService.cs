using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Core.Helpers;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Services;

namespace HotelServiceSystem.Core.Service
{
	public class AdditionalServiceService : IAdditionalServiceService
	{
		private readonly IAdditionalServiceRepository _additionalServiceRepository;

		public AdditionalServiceService(IAdditionalServiceRepository additionalServiceRepository)
		{
			_additionalServiceRepository = additionalServiceRepository;
		}

		public List<AdditionalService> GetAllAdditionalServices(Func<AdditionalService, bool> filter = null)
		{
			return filter != null ? _additionalServiceRepository.GetAll().AsEnumerable().Where(filter).ToList() : _additionalServiceRepository.GetAll().ToList();
		}

		public AdditionalService GetById(int id)
		{
			return _additionalServiceRepository.GetById(id);
		}

		public List<AdditionalService> GetAllAdditionalServicesWithRelations(params Expression<Func<AdditionalService, object>>[] navigationProperties)
		{
			return _additionalServiceRepository.GetAll().IncludeMultiple(navigationProperties).ToList();
		}

		public async Task<AdditionalService> AddAdditionalServiceAsync(AdditionalService service)
		{
			return await _additionalServiceRepository.AddAsync(service);
		}

		public async Task<AdditionalService> UpdateAdditionalServiceAsync(AdditionalService service)
		{
			return await _additionalServiceRepository.UpdateAsync(service);
		}

		public async Task RemoveAdditionalService(AdditionalService service)
		{
			await _additionalServiceRepository.DeleteAsync(service);
		}
	}
}