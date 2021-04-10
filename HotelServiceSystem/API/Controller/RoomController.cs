using System.Collections.Generic;
using System.Threading.Tasks;
using HotelServiceSystem.Core;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.API.Controller
{
	[Route("api/rooms")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		private readonly IRoomService _roomService;

		public RoomController(IRoomService roomService)
		{
			_roomService = roomService;
		}
		
		[HttpPost]
		public async Task<ActionResult<IEnumerable<Room>>> GetAllAvailableRooms([FromBody] ReservationSpan reservationSpan)
		{
			var aviableRooms = await _roomService.GetAvailableRooms(reservationSpan);
			return Ok(aviableRooms);
		}
		
		[HttpGet]
		public  ActionResult<IEnumerable<Room>> GetAllAvailableRooms()
		{
			var aviableRooms =  _roomService.GetAllRoomsAsync();
			return Ok(aviableRooms);
		}
	}
}