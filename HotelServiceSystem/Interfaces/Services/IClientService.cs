using System.Collections.Generic;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Interfaces.Services
{
	public interface IClientService
	{
		List<Client> GetAllClients();
		Task<Client> AddClientAsync(Client client);
		Task<Client> UpdateClientAsync(Client client);
		Task RemoveClientAsync(Client client);
	}
}