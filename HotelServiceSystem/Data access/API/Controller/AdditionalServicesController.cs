using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Data_access.DtoModel;
using HotelServiceSystem.Logic.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Data_access.API.Controller
{
	[Route("api/additionalServices")]
	[ApiController]
	public class AdditionalServicesController : ControllerBase
	{
		private IAdditionalServiceService _additionalServiceService;

		public AdditionalServicesController(IAdditionalServiceService additionalServiceService)
		{
			_additionalServiceService = additionalServiceService;
		}
		
		[HttpGet]
		public ActionResult<IEnumerable<AdditionalServiceDto>> GetReservationAdditionalServices()
		{
			var additionalServices = _additionalServiceService.GetAllAdditionalServices();
			var additionalServicesDto = additionalServices
				.Where(x => x.ServiceType == ServiceType.Reservation)
				.Select(AdditionalServiceDto.From).ToList();

			return Ok(additionalServicesDto);
		}
	}
}