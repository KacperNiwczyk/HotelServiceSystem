using FluentValidation;
using HotelServiceSystem.Domain.Entities;

namespace HotelServiceSystem.Logic.Features.Validations
{
	public class AdditionalServiceValidator : AbstractValidator<AdditionalService>
	{
		private const int MinPrice = 0;
		private const int MaxPrice = 9999;
		
		public AdditionalServiceValidator()
		{
			RuleFor(x => x.Name).NotEmpty()
				.WithMessage("Nazwa dodatkowej usuługi nie może być pusta");
			RuleFor(x => x.Price).GreaterThanOrEqualTo(MinPrice).LessThan(MaxPrice)
				.WithMessage($"Kosz dodatkowej usługi nie może być mniejszy niż {MinPrice} oraz większy od {MaxPrice}");
			RuleFor(x => x.ServiceType).NotNull()
				.WithMessage("Typ dodatkowej usługi nie może być pusty");
		}
	}
}