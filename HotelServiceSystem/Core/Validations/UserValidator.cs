using FluentValidation;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Features.Enums;

namespace HotelServiceSystem.Core.Validations
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(x => x.UserName).NotEmpty().MinimumLength(5);
			RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
			RuleFor(x => x.UserRole).NotNull();
		}
	}
}