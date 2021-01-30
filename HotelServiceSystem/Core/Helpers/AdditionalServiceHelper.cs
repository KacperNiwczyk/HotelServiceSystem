using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Helpers;
using MatBlazor;

namespace HotelServiceSystem.Core.Helpers
{
	public class AdditionalServiceHelper : IAdditionalServiceHelper
	{
		public List<AdditionalService> GetSelectedAdditionalServices(MatChip[] selectedChips, List<AdditionalService> additionalServiceList)
		{
			var selectedServices = new List<AdditionalService>();
			if (selectedChips == null || selectedChips.Length <= 0) return selectedServices;
			selectedServices.AddRange(selectedChips.Select(chip => additionalServiceList.FirstOrDefault(x => x.Id.Equals(chip.Attributes["Id"]))));

			return selectedServices;
		}
	}
	
}