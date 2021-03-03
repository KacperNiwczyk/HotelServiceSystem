using FluentValidation;
using HotelServiceSystem.Entities;

namespace HotelServiceSystem.Core.Validations
{
	public class AdditionalServiceValidator : AbstractValidator<AdditionalService>
	{
		public AdditionalServiceValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Price).GreaterThanOrEqualTo(0).LessThan(9999);
			RuleFor(x => x.ServiceType).NotNull();
		}
	}
}