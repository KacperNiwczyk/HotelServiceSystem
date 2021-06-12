using System;

namespace HotelServiceSystem.Data_access.Core
{
	public class DateManager : IDateManager
	{
		public DateTime Today => DateTime.Today.Date;
	}
}