using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Services;

namespace HotelServiceSystem.Core.Service
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