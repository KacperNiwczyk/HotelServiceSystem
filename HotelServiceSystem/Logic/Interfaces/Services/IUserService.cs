﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Interfaces.Services
{
	public interface IUserService
	{
		List<User> GetAllUserAsync();
		User GetById(int id);
		List<User> GetAllUserWithRelations(params Expression<Func<User, object>>[] navigationProperties);
		Task<User> AddUserAsync(User user);
		Task<User> UpdateUserAsync(User user);
		Task RemoveUserAsync(User user);
	}
}