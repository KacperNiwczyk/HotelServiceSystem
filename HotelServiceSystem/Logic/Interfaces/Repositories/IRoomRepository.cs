using System.Collections.Generic;
using System.Threading.Tasks;
using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Interfaces.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<List<Room>> GetFreeRooms(ReservationSpan reservationSpan);

        Task<List<Room>> GetApiRoomsAsync();
    }
}