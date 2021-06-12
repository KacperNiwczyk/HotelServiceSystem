using System;
using System.Linq;
using System.Linq.Expressions;
using HotelServiceSystem.Data_access.Core;
using HotelServiceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelServiceSystem.Logic.Features.Helpers
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

		public static int CountBeds(this Room room, BedType bedType)
		{
			return room.Beds.Count(x => x.BedType == bedType);
		}

		public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable) where T : class
		{
			var type = typeof(T);
			var properties = type.GetProperties();
			foreach (var property in properties)
			{
				var isVirtual = property.GetGetMethod().IsVirtual;
				if (isVirtual && properties.FirstOrDefault(c => c.Name == property.Name + "Id") != null)
				{
					queryable = queryable.Include(property.Name);
				}
			}

			return queryable;
		}
	}
}