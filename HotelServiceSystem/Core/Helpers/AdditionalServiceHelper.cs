﻿using System;
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
			selectedServices.AddRange(selectedChips.Select(chip => additionalServiceList.FirstOrDefault(x => x.Name.Equals(chip.Label, StringComparison.InvariantCultureIgnoreCase))));

			return selectedServices;
		}

		public void ParseChipToAdditionalService(MatChip[] selectedChips, List<AdditionalService> additionalServiceList,
			List<AdditionalService> selectedServices)
		{
			if (selectedServices == null) 
				return;
			
			var parsedChips = GetSelectedAdditionalServices(selectedChips, additionalServiceList);
			selectedServices.AddRange(parsedChips.FindAll(x => !selectedServices.Contains(x)));
		}
	}
	
}