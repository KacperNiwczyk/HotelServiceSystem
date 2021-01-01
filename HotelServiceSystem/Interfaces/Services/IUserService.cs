using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Services
{
	public interface IUserService
	{
		List<User> GetAllUserAsync();
		List<User> GetAllUserWithRelations(params Expression<Func<User, object>>[] navigationProperties);
		Task<User> AddUserAsync(User user);
		Task<User> UpdateUserAsync(User user);
		Task RemoveUserAsync(User user);
	}
}