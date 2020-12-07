using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HotelServiceSystem.Core.Components
{
	public class HssBaseInput : InputBase<string>
	{
		[Parameter] public string Id { get; set; }
		[Parameter] public string Label { get; set; }
		[Parameter] public Expression<Func<string>> ValidationFor { get; set; }

		protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
		{
			result = value;
			validationErrorMessage = null;
			return true;
		}
	}
}