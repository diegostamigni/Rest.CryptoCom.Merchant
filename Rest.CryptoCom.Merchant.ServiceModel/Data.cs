using System.Text.Json;

namespace Rest.CryptoCom.Merchant.ServiceModel
{
	public record Data
	{
		public JsonElement? Object { get; set; }
	}
}