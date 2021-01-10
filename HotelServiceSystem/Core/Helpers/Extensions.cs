using System;
using System.Linq;
using System.Linq.Expressions;
using HotelServiceSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Core.Helpers
{
	public static class Extensions
	{
		public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
			where T : class
		{
			if (includes != null)
			{
				query = includes.Aggregate(query, (current, include) => current.Include(include));
			}
			return query;
		}

		public static string GetAutocompleteValue(this Client client)
		{
			return client == null ? string.Empty : $"{client.FirstName} {client.LastName} - {client.PhoneNumber}";
		}
	}
}