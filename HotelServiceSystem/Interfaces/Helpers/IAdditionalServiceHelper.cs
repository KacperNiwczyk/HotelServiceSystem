using System.Collections.Generic;
using HotelServiceSystem.Entities;
using MatBlazor;

namespace HotelServiceSystem.Interfaces.Helpers
{
	public interface IAdditionalServiceHelper
	{
		List<AdditionalService> GetSelectedAdditionalServices(MatChip[] selectedChips, List<AdditionalService> additionalServices);

		void ParseChipToAdditionalService(MatChip[] selectedChips, List<AdditionalService> additionalServiceList,
			List<AdditionalService> selectedServices);
	}
}