using FluentValidation;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Features.Validations
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