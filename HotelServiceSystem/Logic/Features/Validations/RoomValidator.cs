using FluentValidation;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Features.Validations
{
	public class RoomValidator : AbstractValidator<Room>
	{
		public RoomValidator()
		{
			RuleFor(x => x.RoomIdentifier).NotEmpty();
			RuleFor(x => x.Price).GreaterThan(0);
			RuleFor(x => x.Floor).GreaterThan(0);
			RuleFor(x => x.Beds).Must(x => x.Count > 0);
		}
	}
}