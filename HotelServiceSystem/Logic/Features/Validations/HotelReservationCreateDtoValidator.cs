using System;
using System.Globalization;
using FluentValidation;
using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Data_access.DtoModel;
using HotelServiceSystem.Logic.Features.Helpers;

namespace HotelServiceSystem.Logic.Features.Validations
{
	public class HotelReservationCreateDtoValidator : AbstractValidator<HotelReservationCreateDto>
	{
		private static readonly string IncorrectDateFormatMessage = $"Data musi być podana w poprawnym formacie {Constants.DefaultDateFormat}";

		public HotelReservationCreateDtoValidator()
		{
			RuleFor(x => x.ClientDto).SetValidator(new ClientDtoValidator());
			RuleFor(x => x.DateFrom).Must(BeProperArrivalDate)
				.WithMessage(IncorrectDateFormatMessage + " i być późniejsza lub równa dziś.");
			RuleFor(x => x.DateTo).Must(BeProperDate)
				.WithMessage(IncorrectDateFormatMessage);
			RuleFor(x => x).Must(HaveProperDates)
				.WithMessage($"Data przybycia musi być mniejsza niż data wymeldowania");
		}

		private bool BeProperArrivalDate(string date)
		{
			var dateManager = new DateManager();
			return DateTime.TryParseExact(date, Constants.DefaultDateFormat, CultureInfo.InvariantCulture,
				DateTimeStyles.None, out var dateTime) && dateTime >= dateManager.Today;
		}

		private bool HaveProperDates(HotelReservationCreateDto arg)
		{
			var dateFrom = DateTime.Parse(arg.DateFrom);
			var dateTo = DateTime.Parse(arg.DateTo);
			return dateFrom < dateTo;
		}

		private bool BeProperDate(string date)
		{
			return DateTime.TryParseExact(date, Constants.DefaultDateFormat, CultureInfo.InvariantCulture,
				DateTimeStyles.None, out _);
		}
	}
}