using FluentValidation;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Validations
{
	public class HotelReservationValidator : AbstractValidator<HotelReservation>
	{
		public HotelReservationValidator()
		{
			RuleFor(x => x.Client).NotNull();
			RuleFor(x => x.Client.Id).NotEmpty().When(x => x.Client != null);
			RuleFor(x => x.Client.Id).NotEqual(0).When(x => x.Client != null);
			RuleFor(x => x.DateFrom).NotEmpty();
			RuleFor(x => x.DateTo).NotEmpty();
		}
	}
}