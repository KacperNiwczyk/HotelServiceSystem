using FluentValidation;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Validations
{
	public class ClientValidator : AbstractValidator<Client>
	{
		public ClientValidator()
		{
			RuleFor(x => x).NotNull();
			RuleFor(x => x.Id).NotEmpty();
		}
	}
}