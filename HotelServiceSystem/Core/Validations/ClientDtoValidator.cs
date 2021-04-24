using FluentValidation;
using HotelServiceSystem.DtoModel;

namespace HotelServiceSystem.Core.Validations
{
	public class ClientDtoValidator : AbstractValidator<ClientDto>
	{
		public ClientDtoValidator()
		{
			RuleFor(x => x.FirstName).NotEmpty();
			RuleFor(x => x.LastName).NotEmpty();
			RuleFor(x => x.Email).NotEmpty();
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.PhoneNumber).NotEmpty();
		}
	}
}