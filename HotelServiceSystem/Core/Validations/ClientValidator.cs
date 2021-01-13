using FluentValidation;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Validations
{
	public class ClientValidator : AbstractValidator<Client>
	{
		public ClientValidator()
		{
			RuleFor(x => x).NotNull();
			RuleFor(x => x.FirstName).MaximumLength(25).NotEmpty();
			RuleFor(x => x.LastName).MaximumLength(25).NotEmpty();
			RuleFor(x => x.Email).NotEmpty();
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.PhoneNumber).NotEmpty();
		}
	}
}