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
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public List<User> GetAllUserAsync()
		{
			return _userRepository.GetAll().ToList();
		}

		public User GetById(int id)
		{
			return _userRepository.GetById(id);
		}

		public List<User> GetAllUserWithRelations(params Expression<Func<User, object>>[] navigationProperties)
		{
			return _userRepository.GetAll().IncludeMultiple(navigationProperties).ToList();
		}

		public async Task<User> AddUserAsync(User user)
		{
			return await _userRepository.AddAsync(user);
		}

		public async Task<User> UpdateUserAsync(User user)
		{
			return await _userRepository.UpdateAsync(user);
		}

		public async Task RemoveUserAsync(User user)
		{
			await _userRepository.DeleteAsync(user);
		}
	}
}