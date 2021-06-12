using System;

namespace HotelServiceSystem.Data_access.Core
{
	public interface IDateManager
	{
		DateTime Today { get; }
	}
}