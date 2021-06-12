using System.Collections.Generic;
using FluentValidation;

namespace HotelServiceSystem.Logic.Features.Validations
{
	public class MultiSelectValidator : AbstractValidator<List<MultiSelector>>
	{
		public MultiSelectValidator()
		{
			RuleFor(x => x).NotNull();
			RuleFor(x => x.Count).GreaterThan(0);
		}
	}
}