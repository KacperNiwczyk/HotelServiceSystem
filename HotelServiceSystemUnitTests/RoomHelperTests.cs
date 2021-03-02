using System;
using HotelServiceSystem.Core;
using HotelServiceSystem.Core.Helpers;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Helpers;
using NUnit.Framework;

namespace HotelServiceSystemUnitTests
{
	[TestFixture]
	public class RoomHelperTests
	{
		private IRoomHelper _roomHelper;
		private Room _fakeRoom;
		private static RoomHelperTestTestData[] _testDataSource =
		{
			new RoomHelperTestTestData(new DateTime(2021, 01, 09), new DateTime(2021, 01, 10), true),
			new RoomHelperTestTestData(new DateTime(2021, 01, 05), new DateTime(2021, 01, 06), false),
			new RoomHelperTestTestData(new DateTime(2021, 01, 04), new DateTime(2021, 01, 05), false),
			new RoomHelperTestTestData(new DateTime(2021, 02, 06), new DateTime(2021, 02, 07), true),
			new RoomHelperTestTestData(new DateTime(2021, 01, 15), new DateTime(2021, 01, 18), false),
		};

		[SetUp]
		public void Init()
		{
			_roomHelper = new RoomHelper();
			_fakeRoom = new Room()
			{
				Id = 100,
				Floor = 2,
				RoomIdentifier = "100",
				RoomReservations =
				{
					new RoomReservation()
					{
						Reservation = new Reservation()
						{
							DateFrom = new DateTime(2021, 01, 06),
							DateTo = new DateTime(2021, 01, 07)
						}
					},
					new RoomReservation()
					{
						Reservation = new Reservation()
						{
							DateFrom = new DateTime(2021, 01, 05),
							DateTo = new DateTime(2021, 01, 08)
						}
					},
					new RoomReservation()
					{
						Reservation = new Reservation()
						{
							DateFrom = new DateTime(2021, 01, 05),
							DateTo = new DateTime(2021, 01, 06)
						}
					},
					new RoomReservation()
					{
						Reservation = new Reservation()
						{
							DateFrom = new DateTime(2021, 01, 07),
							DateTo = new DateTime(2021, 01, 08)
						}
					},
					new RoomReservation()
					{
						Reservation = new Reservation()
						{
							DateFrom = new DateTime(2021, 01, 17),
							DateTo = new DateTime(2021, 01, 21)
						}
					}
				}
			};

			
		}
		
		[Test]
		public void IsFree_CheckIfRoomIsFree_ReturnProperValue([ValueSource(nameof(_testDataSource))]RoomHelperTestTestData testData)
		{
			//Arrange
			//Act
			var result = _roomHelper.IsFree(_fakeRoom, new ReservationSpan(testData.DateFrom, testData.DateTo));
			
			Assert.AreEqual(testData.ExpectedResult, result);
		}
	}

	public class RoomHelperTestTestData
	{ 
		internal DateTime DateFrom { get; set; }
		internal DateTime DateTo { get; set; }
		internal bool ExpectedResult { get; set; }

		public RoomHelperTestTestData(DateTime aDateFrom, DateTime aDateTo, bool aExpectedResult)
		{
			DateFrom = aDateFrom;
			DateTo = aDateTo;
			ExpectedResult = aExpectedResult;
		}
	}
}