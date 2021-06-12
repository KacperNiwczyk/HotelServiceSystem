using FluentValidation;
using HotelServiceSystem.Domain.Entities;
using HotelServiceSystem.ViewModel;

namespace HotelServiceSystem.Logic.Features.Validations
{
	public class HotelReservationValidator : AbstractValidator<HotelReservationViewModel>
	{
		public HotelReservationValidator()
		{
			RuleFor(x => x.Client).NotNull();
			RuleFor(x => x.Client.Id).NotEmpty().When(x => x.Client != null).WithMessage("Pole client nie może być puste");
			RuleFor(x => x.DateRange).NotEmpty();
			RuleFor(x => x.NumberOfGuests).NotEmpty().GreaterThan(0);
			RuleFor(x => x.SelectedRooms).NotNull();
			RuleFor(x => x.SelectedRooms).Must(x => x.Count > 0);
		}
	}
}