﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core
{
    public interface IRoomRepository : IRepository<Room>
    {
        List<Room> GetFreeRooms(ReservationSpan reservationSpan);
    }
}