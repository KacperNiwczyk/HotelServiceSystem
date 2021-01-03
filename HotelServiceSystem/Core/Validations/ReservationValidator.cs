﻿using FluentValidation;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Validations
{
	public class ReservationValidator : AbstractValidator<HotelReservation>
	{
		public ReservationValidator()
		{
			RuleFor(x => x.Client.Id).NotEmpty().When(x => x.Client != null);
			RuleFor(x => x.DateFrom).NotEmpty();
			RuleFor(x => x.DateTo).NotEmpty();
		}
	}
}