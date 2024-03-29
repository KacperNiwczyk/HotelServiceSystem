﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Interfaces.Services
{
	public interface IAdditionalServiceService
	{
		List<AdditionalService> GetAllAdditionalServices(Func<AdditionalService, bool> filter = null);

		AdditionalService GetById(int id);
		List<AdditionalService> GetAllAdditionalServicesWithRelations(
			params Expression<Func<AdditionalService, object>>[] navigationProperties);

		Task<AdditionalService> AddAdditionalServiceAsync(AdditionalService service);

		Task<AdditionalService> UpdateAdditionalServiceAsync(AdditionalService service);

		Task RemoveAdditionalService(AdditionalService service);
	}
}