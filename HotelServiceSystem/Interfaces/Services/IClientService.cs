using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Services
{
	public interface IClientService
	{
		List<Client> GetAllClients();
		Client GetById(int id);
		List<Client> GetAllWithRelations(params Expression<Func<Client, object>>[] navigationProperties);
		Task<Client> AddClientAsync(Client client);
		Task<Client> UpdateClientAsync(Client client);
		Task RemoveClientAsync(Client client);
	}
}