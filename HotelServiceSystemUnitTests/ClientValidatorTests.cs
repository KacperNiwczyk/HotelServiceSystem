using System.Collections.Generic;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Features.Validations;
using NUnit.Framework;

namespace HotelServiceSystemUnitTests
{
	[TestFixture]
	public class ClientValidatorTests
	{
		private ClientValidator _clientValidator;
		private Client fakeClient;

		[SetUp]
		private void Init()
		{
			_clientValidator = new ClientValidator();
			
			fakeClient = new Client
			{
				Reservations = new List<Reservation>()
			};
		}
	}
}