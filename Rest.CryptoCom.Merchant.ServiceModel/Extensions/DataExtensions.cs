using System.Text.Json;

namespace Rest.CryptoCom.Merchant.ServiceModel.Extensions
{
	public static class DataExtensions
	{
		public static T? As<T>(this Data data)
		{
			if (data.Object is null)
			{
				return default;
			}

			return JsonSerializer.Deserialize<T>(data.Object.Value.GetRawText(), new()
			{
				PropertyNameCaseInsensitive = true
			});
		}
	}
}