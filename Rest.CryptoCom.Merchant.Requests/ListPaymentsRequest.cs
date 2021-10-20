using System.Text.Json.Serialization;

namespace Rest.CryptoCom.Merchant.Requests
{
	public class ListPaymentsRequest
	{
		/// <summary>
		/// Filter by payment created time. Measured in seconds since the Unix epoch.
		/// </summary>
		[JsonPropertyName("created_at_begin")]
		public long? CreatedAtBegin { get; set; }

		/// <summary>
		/// Filter by payment created time. Measured in seconds since the Unix epoch.
		/// </summary>
		[JsonPropertyName("created_at_end")]
		public long? CreatedAtEnd { get; set; }

		/// <summary>
		/// Filter by payment captured time. Measured in seconds since the Unix epoch.
		/// </summary>
		[JsonPropertyName("captured_at_begin")]
		public long? CapturedAtBegin { get; set; }

		/// <summary>
		/// Filter by payment captured time. Measured in seconds since the Unix epoch.
		/// </summary>
		[JsonPropertyName("captured_at_end")]
		public long? CapturedAtEnd { get; set; }

		/// <summary>
		/// Number of payments to be listed per page (10 - 100).
		/// </summary>
		[JsonPropertyName("per_page")]
		public int? PerPage { get; set; }

		/// <summary>
		/// Current page number.
		/// </summary>
		public int? Page { get; set; }
	}
}