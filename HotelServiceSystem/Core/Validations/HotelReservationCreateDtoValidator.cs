using System;
using System.Globalization;
using FluentValidation;
using HotelServiceSystem.Core.Helpers;
using HotelServiceSystem.DtoModel;

namespace HotelServiceSystem.Core.Validations
{
	public class HotelReservationCreateDtoValidator : AbstractValidator<HotelReservationCreateDto>
	{
		private static readonly string IncorrectDateFormatMessage = $"Date must be provided in proper format {Constants.DefaultDateFormat}";

		public HotelReservationCreateDtoValidator()
		{
			RuleFor(x => x.ClientDto).SetValidator(new ClientDtoValidator());
			RuleFor(x => x.DateFrom).Must(BeProperArrivalDate)
				.WithMessage(IncorrectDateFormatMessage + " and has to be higher or equal to today's date");
			RuleFor(x => x.DateTo).Must(BeProperDate)
				.WithMessage(IncorrectDateFormatMessage);
			RuleFor(x => x).Must(HaveProperDates)
				.WithMessage($"Date of arrival must be lower then date of departure");
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