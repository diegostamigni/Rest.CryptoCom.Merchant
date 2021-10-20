using System.Text.Json.Serialization;

namespace Rest.CryptoCom.Merchant.ServiceModel
{
	public record Webhook
	{
		public string? Id { get; set; }

		[JsonPropertyName("object_type")]
		public string? ObjectType { get; set; }

		public string? Type { get; set; }

		public long? Created { get; set; }

		public Data? Data { get; set; }
	}
}