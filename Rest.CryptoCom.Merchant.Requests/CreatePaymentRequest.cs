using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rest.CryptoCom.Merchant.Requests
{
	/// <summary>
	///
	/// </summary>
	/// <param name="Amount">A positive integer representing how much to collect in the smallest currency unit (e.g., 100 cents to charge $1.00)</param>
	/// <param name="Currency">Three-letter ISO currency code, in uppercase. Must be a supported currency.</param>
	public record CreatePaymentRequest(int Amount, string Currency)
	{
		/// <summary>
		/// An arbitrary string attached to the object.
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Set of key-value pairs that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
		/// </summary>
		public Dictionary<string, object>? Metadata { get; set; }

		/// <summary>
		/// Merchant provided order ID for this payment.
		/// </summary>
		[JsonPropertyName("order_id")]
		public string? OrderId { get; set; }

		/// <summary>
		/// The URL for payment page to redirect back to when the payment becomes succeeded. It is required for redirection flow.
		/// </summary>
		[JsonPropertyName("return_url")]
		public string? ReturnUrl { get; set; }

		/// <summary>
		/// The URL for payment page to redirect to when the payment is failed or cancelled.
		/// </summary>
		[JsonPropertyName("cancel_url")]
		public string? CancelUrl { get; set; }
	}
}