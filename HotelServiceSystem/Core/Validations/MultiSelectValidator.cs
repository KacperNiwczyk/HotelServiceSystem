using System.Collections.Generic;
using FluentValidation;
using HotelServiceSystem.Features;

namespace HotelServiceSystem.Core.Validations
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