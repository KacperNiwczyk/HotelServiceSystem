using FluentValidation;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Validations
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