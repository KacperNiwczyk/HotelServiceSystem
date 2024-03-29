﻿using System;
using System.Collections.Generic;
using HotelServiceSystem.Domain.Entities;
using MudBlazor;

namespace HotelServiceSystem.ViewModel
{
	public class ReservationViewModel
	{
		public int Id { get; set; }
        
		public Client Client { get; set; }
        
		public int NumberOfGuests { get; set; }
		
		public DateRange DateRange { get; set; }
		
		public double Price { get; set; }
        
		public DateTime DateOfSubmission { get; set; }
        
		public double Discount { get; set; }
        
		public bool HasFinished { get; set; }
        
		public List<Room> SelectedRooms { get; set; }
        
		public List<AdditionalService> SelectedAdditionalServices { get; set; }
	}
}