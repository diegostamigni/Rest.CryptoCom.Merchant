using System.Text.Json.Serialization;

namespace Rest.CryptoCom.Merchant.Responses
{
	public class Metadata
	{
		[JsonPropertyName("current_page")]
		public int? CurrentPage { get; set; }

		[JsonPropertyName("current_size")]
		public int? CurrentSize { get; set; }

		[JsonPropertyName("next_page")]
		public int? NextPage { get; set; }

		[JsonPropertyName("per_page")]
		public int? PerPage { get; set; }

		[JsonPropertyName("total_pages")]
		public int? TotalPages { get; set; }
	}
}