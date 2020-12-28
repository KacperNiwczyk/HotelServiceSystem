namespace HotelServiceSystem.Features
{
	public struct MultiSelector
	{
		public string Key { get; set; }
		public string Value { get; set; }

		public MultiSelector(string key, string value)
		{
			Key = key;
			Value = value;
		}
	}
}