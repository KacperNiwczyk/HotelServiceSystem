using System;
using System.Linq;
using FluentValidation;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Validations
{
	public class ClientValidator : AbstractValidator<Client>
	{
		private const int FirstNameLastNameMaxLength = 25;
		private const int CompanyNameMaxLength = 100;
		public ClientValidator()
		{
			RuleFor(x => x).NotNull();
			RuleFor(x => x.FirstName).MaximumLength(25).NotEmpty()
				.WithMessage($"First name cannot be empty or longer than {FirstNameLastNameMaxLength}");
			RuleFor(x => x.LastName).MaximumLength(25).NotEmpty()
				.WithMessage($"Last name cannot be empty or longer than {FirstNameLastNameMaxLength}");
			RuleFor(x => x.CompanyName).MaximumLength(100)
				.WithMessage($"Company name cannot be longer than {CompanyNameMaxLength} characters");
			RuleFor(x => x.Email).NotEmpty().EmailAddress()
				.WithMessage("Email address cannot be empty and must have valid email format");
			RuleFor(x => x.PhoneNumber).NotEmpty()
				.WithMessage("Phone number cannot be empty");
			RuleFor(x => x.TaxId).Must(BeNumber)
				.WithMessage("Tax ID should contain only digits");
		}

		private static bool BeNumber(string taxId)
		{
			return taxId == null || taxId.Equals(string.Empty) || taxId.All(char.IsDigit);
		}
	}
}