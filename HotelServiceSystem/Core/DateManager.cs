using System;

namespace HotelServiceSystem.Core
{
	public class DateManager : IDateManager
	{
		public DateTime Today => DateTime.Today.Date;
	}
}