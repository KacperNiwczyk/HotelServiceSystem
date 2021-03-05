using FluentValidation;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Validations
{
	public class HotelReservationValidator : AbstractValidator<HotelReservation>
	{
		public HotelReservationValidator()
		{
			RuleFor(x => x.Client).NotNull();
			RuleFor(x => x.Client.Id).NotEmpty().When(x => x.Client != null).WithMessage("Pole client nie może być puste");
			RuleFor(x => x.DateFrom).NotEmpty();
			RuleFor(x => x.DateTo).NotEmpty();
			RuleFor(x => x.NumberOfGuests).NotEmpty().GreaterThan(0);
			RuleFor(x => x.RoomReservations).NotNull();
			RuleFor(x => x.RoomReservations).Must(x => x.Count > 0);
		}
	}
}