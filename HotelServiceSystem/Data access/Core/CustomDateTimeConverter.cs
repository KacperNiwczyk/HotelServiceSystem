using Newtonsoft.Json.Converters;

namespace HotelServiceSystem.Data_access.Core
{
	public class CustomDateTimeConverter : IsoDateTimeConverter
	{
		public CustomDateTimeConverter()
		{
			base.DateTimeFormat = "dd/MM/yyyy";
		}
	}
}