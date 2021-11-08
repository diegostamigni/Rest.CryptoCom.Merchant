using System;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Web;

namespace Rest.CryptoCom.Merchant
{
	internal static class UriHelper
	{
		public static UriBuilder BuildQuery<TRequest>(TRequest request, Uri uri) where TRequest : class
		{
			var uriBuilder = new UriBuilder(uri);
			var query = HttpUtility.ParseQueryString(uriBuilder.Query);

			foreach (var property in request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				var propertyValue = property.GetValue(request);
				if (propertyValue is null)
				{
					continue;
				}

				if (property.IsDefined(typeof(JsonPropertyNameAttribute)))
				{
					var jsonName = property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name;
					if (jsonName != null)
					{
						query[jsonName] = $"{propertyValue}";
					}
				}
				else
				{
					query[property.Name.ToLowerInvariant()] = $"{propertyValue}";
				}
			}

			uriBuilder.Query = query.ToString();
			return uriBuilder;
		}
	}
}