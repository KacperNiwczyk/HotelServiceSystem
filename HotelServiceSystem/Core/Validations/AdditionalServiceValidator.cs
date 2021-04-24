using FluentValidation;
using HotelServiceSystem.Entities;
using MudBlazor;

namespace HotelServiceSystem.Core.Validations
{
	public class AdditionalServiceValidator : AbstractValidator<AdditionalService>
	{
		private const int MinPrice = 0;
		private const int MaxPrice = 9999;
		
		public AdditionalServiceValidator()
		{
			RuleFor(x => x.Name).NotEmpty()
				.WithMessage("Additional service name cannot be empty");
			RuleFor(x => x.Price).GreaterThanOrEqualTo(MinPrice).LessThan(MaxPrice)
				.WithMessage($"Additional service Price should be higher than {MinPrice} and less than {MaxPrice}");
			RuleFor(x => x.ServiceType).NotNull()
				.WithMessage("Additional service type cannot be empty");
		}
	}
}