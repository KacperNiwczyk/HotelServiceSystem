using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Features.Helpers;
using HotelServiceSystem.Logic.Interfaces.Repositories;
using HotelServiceSystem.Logic.Interfaces.Services;

namespace HotelServiceSystem.Logic.Features.Service
{
	public class ClientService : IClientService
	{
		private readonly IClientRepository _clientRepository;

		public ClientService(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}
		
		public List<Client> GetAllClients()
		{
			return _clientRepository.GetAll().ToList();
		}

		public Client GetById(int id)
		{
			return _clientRepository.GetById(id);
		}

		public List<Client> GetAllWithRelations(params Expression<Func<Client, object>>[] navigationProperties)
		{
			return _clientRepository.GetAll().IncludeMultiple(navigationProperties).ToList();
		}

		public async Task<Client> AddClientAsync(Client client)
		{
			return await _clientRepository.AddAsync(client);
		}

		public async Task<Client> UpdateClientAsync(Client client)
		{
			return await _clientRepository.UpdateAsync(client);
		}

		public async Task RemoveClientAsync(Client client)
		{
			 await _clientRepository.DeleteAsync(client);
		}
	}
}