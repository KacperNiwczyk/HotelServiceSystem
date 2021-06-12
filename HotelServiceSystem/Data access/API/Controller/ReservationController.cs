using System.Linq;
using System.Threading.Tasks;
using HotelServiceSystem.Data_access.DtoModel;
using HotelServiceSystem.Logic.Features.Validations;
using HotelServiceSystem.Logic.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Data_access.API.Controller
{
	[Route("api/reservation")]
	[ApiController]
	public class ReservationController : ControllerBase
	{
		private readonly IHotelReservationService _hotelReservationService;
		private readonly IRoomService _roomService;
		private readonly IAdditionalServiceService _additionalServiceService;

		public ReservationController(IHotelReservationService hotelReservationService, IAdditionalServiceService additionalServiceService, IRoomService roomService)
		{
			_hotelReservationService = hotelReservationService;
			_additionalServiceService = additionalServiceService;
			_roomService = roomService;
		}

		[HttpPost]
		public async Task<ActionResult<CreateResponseDto>> CreateOnlineReservation([FromBody] HotelReservationCreateDto createDto)
		{
			var reservationValidator = new HotelReservationCreateDtoValidator();
			var result = await reservationValidator.ValidateAsync(createDto);
			if (!result.IsValid)
			{
				var errorResponse = new CreateResponseDto
				{
					Status = "Error",
					Errors = result.Errors.Select(x => x.ErrorMessage).ToArray()
				};

				return BadRequest(errorResponse);
			}
			
			var toBeAdded = await createDto.To(_roomService, _additionalServiceService);
			var added = await _hotelReservationService.AddHotelReservationAsync(toBeAdded);
			
			var response = new CreateResponseDto()
			{
				Status = "Success",
				Price = added.Price,
				ReservationId = added.Id.ToString()
			};
			
			return Ok(response);
		}
	}
}