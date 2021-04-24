using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelServiceSystem.Core;
using HotelServiceSystem.DtoModel;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Helpers;
using HotelServiceSystem.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.API.Controller
{
	[Route("api/rooms")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		private readonly IRoomService _roomService;
		private readonly IRoomHelper _roomHelper;

		public RoomController(IRoomService roomService, IRoomHelper roomHelper)
		{
			_roomService = roomService;
			_roomHelper = roomHelper;
		}
		
		 [HttpPost]
		 public async Task<ActionResult<IEnumerable<RoomDto>>> GetAllAvailableRooms([FromBody] ReservationSpan reservationSpan)
		 {
		 	var aviableRooms = await _roomService.GetAvailableRooms(reservationSpan);
		    var dtoRooms = aviableRooms.Where(x => _roomHelper.IsFree(x, reservationSpan)).Select(RoomDto.From).ToArray();
		 	return Ok(dtoRooms);
		 }
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<RoomDto>>> GetAllRooms()
		{
			var aviableRooms = await _roomService.GetAllRoomsAPI();
			var dtoRooms = aviableRooms.Select(RoomDto.From).ToArray();
			
			return Ok(dtoRooms);
		}
	}
}