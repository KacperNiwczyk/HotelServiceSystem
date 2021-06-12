using System.Linq;
using FluentValidation;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Features.Validations
{
	public class ClientValidator : AbstractValidator<Client>
	{
		private const int FirstNameLastNameMaxLength = 25;
		private const int CompanyNameMaxLength = 100;
		public ClientValidator()
		{
			RuleFor(x => x).NotNull();
			RuleFor(x => x.FirstName).MaximumLength(25).NotEmpty()
				.WithMessage($"Imię nie może być puste ani dłuższe niż {FirstNameLastNameMaxLength} znaków");
			RuleFor(x => x.LastName).MaximumLength(25).NotEmpty()
				.WithMessage($"Nazwisko nie może być puste ani dłuższe niż {FirstNameLastNameMaxLength} zanków");
			RuleFor(x => x.CompanyName).MaximumLength(100)
				.WithMessage($"Nazwa firmy nie może być dłuższa niż {CompanyNameMaxLength} znaków");
			RuleFor(x => x.Email).NotEmpty().EmailAddress()
				.WithMessage("Adres email nie może być pusty i musi posiadać poprawny format");
			RuleFor(x => x.PhoneNumber).NotEmpty()
				.WithMessage("Numer telefonu nie może być pusty");
			RuleFor(x => x.TaxId).Must(BeNumber)
				.WithMessage("NIP może zawierać tylko cyfry");
		}

		private static bool BeNumber(string taxId)
		{
			return taxId == null || taxId.Equals(string.Empty) || taxId.All(char.IsDigit);
		}
	}
}