using System;
using System.Linq;
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
			RuleFor(x => x.CompanyName).MaximumLength(100);
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
			RuleFor(x => x.PhoneNumber).NotEmpty();
			RuleFor(x => x.TaxId).Must(BeNumber).WithMessage("Tax ID musi składać się z cyfr");
		}

		private static bool BeNumber(string taxId)
		{
			return taxId == null || taxId.Equals(string.Empty) || taxId.All(char.IsDigit);
		}
	}
}