using System.Collections.Generic;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.Logic.Features.Helpers;
using HotelServiceSystem.Logic.Interfaces.Helpers;
using NUnit.Framework;

namespace HotelServiceSystemUnitTests
{
	[TestFixture]
	public class ReservationHelperTests
	{
		private IReservationHelper ReservationHelper;

		[SetUp]
		public void Init()
		{
			ReservationHelper = new ReservationHelper();
		}

		[Test]
		public void GetClientValue_ReturnProperValue()
		{
			//Arrange
			var fakeClient = new Client() {FirstName = "John", LastName = "Doe"};
			//Act
			var result = ReservationHelper.GetClientFirstNameLastName(fakeClient);
			
			Assert.AreEqual("John Doe", result);
		}

		[Test]
		public void GetRoomValue_ReturnProperValue()
		{
			//Arrange
			var roomReservations = new List<RoomReservation>()
			{
				InitializeRoomReservation("1"),
				InitializeRoomReservation("2"),
				InitializeRoomReservation("4"),
				InitializeRoomReservation("6"),
				InitializeRoomReservation("11"),
				InitializeRoomReservation("32"),
			};
			
			//Act
			var result = ReservationHelper.GetRoomValues(roomReservations);
			
			//Assert
			Assert.AreEqual("1, 2, 4, 6, 11, 32", result);
		}

		[Test]
		public void CalculatePrice_WithoutAdditionalServicesAndOneDay_ReturnPriceOfRooms()
		{
			//Arrange
			var roomReservations = new List<Room>()
			{
				InitializeRoom(60),
				InitializeRoom(60),
				InitializeRoom(120),
			};
			
			var additionalServicesReservations = new List<AdditionalService>();
			
			//Act
			var result = ReservationHelper.GetReservationPrice(roomReservations, additionalServicesReservations, 1);

			//Assert
			Assert.AreEqual(240, result);
		}
		
		[Test]
		public void CalculatePrice_WithoutRoomsAndOneDay_ReturnPriceOfRooms()
		{
			//Arrange
			var roomReservations = new List<Room>();
			var additionalServicesReservations = new List<AdditionalService>()
			{
				InitializeAdditionalService(10),
				InitializeAdditionalService(15),
				InitializeAdditionalService(50)
			};
			
			//Act
			var result = ReservationHelper.GetReservationPrice(roomReservations, additionalServicesReservations, 1);

			//Assert
			Assert.AreEqual(75, result);
		}
		
		[Test]
		public void CalculatePrice_WithoutRoomsAndAdditionalServicesAndOneDay_ReturnPriceOfRooms()
		{
			//Arrange
			var roomReservations = new List<Room>()
			{
				InitializeRoom(60),
				InitializeRoom(60),
				InitializeRoom(120),
			};

			var additionalServicesReservations = new List<AdditionalService>()
			{
				InitializeAdditionalService(10),
				InitializeAdditionalService(15),
				InitializeAdditionalService(50)
			};
			
			//Act
			var result = ReservationHelper.GetReservationPrice(roomReservations, additionalServicesReservations, 1);

			//Assert
			Assert.AreEqual(315, result);
		}
		
		[TestCase(1, 250)]
		[TestCase(2, 500)]
		[TestCase(3, 750)]
		[TestCase(4, 1000)]
		public void CalculatePrice_WithoutRoomsAndAdditionalServicesMultipleDays_ReturnPriceOfRooms(int numberOfDays, double expectedPrice)
		{
			//Arrange
			var roomReservations = new List<Room>()
			{
				InitializeRoom(60),
				InitializeRoom(60),
				InitializeRoom(120),
			};

			var additionalServicesReservations = new List<AdditionalService>()
			{
				InitializeAdditionalService(10),
			};
			
			//Act
			var result = ReservationHelper.GetReservationPrice(roomReservations, additionalServicesReservations, numberOfDays);

			//Assert
			Assert.AreEqual(expectedPrice, result);
		}

		private RoomReservation InitializeRoomReservation(string roomIdentifier)
		{
			return new RoomReservation()
			{
				Room = new Room()
				{
					RoomIdentifier = roomIdentifier
				}
			};
		}

		private Room InitializeRoom(double price)
		{
			return new Room()
			{
				Price = price
			};
		}

		private AdditionalService InitializeAdditionalService(double price)
		{
			return new AdditionalService()
			{
				Price = price
			};
		}
	}
}