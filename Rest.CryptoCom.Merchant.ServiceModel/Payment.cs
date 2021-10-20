using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rest.CryptoCom.Merchant.ServiceModel
{
	/// <summary>
	///
	/// </summary>
	/// <param name="Id">Unique identifier for the object.</param>
	public record Payment(string Id)
	{
		/// <summary>
		/// A positive integer representing how much to collect in the smallest currency unit (e.g., 100 cents to collect $1.00).
		/// </summary>
		public int? Amount { get; set; }

		/// <summary>
		/// Amount in cents refunded (can be less than the amount attribute on the payment if a partial refund was issued).
		/// </summary>
		[JsonPropertyName("amount_refunded")]
		public int? AmountRefunded { get; set; }

		/// <summary>
		/// Time at which the object was created. Measured in seconds since the Unix epoch.
		/// </summary>
		public long? Created { get; set; }

		/// <summary>
		/// The cryptocurrency to be collected for this payment.
		/// </summary>
		[JsonPropertyName("crypto_currency")]
		public string? CryptoCurrency { get; set; }

		/// <summary>
		/// The amount of cryptocurrency to be collected for this payment.
		/// </summary>
		[JsonPropertyName("crypto_amount")]
		public string? CryptoAmount { get; set; }

		/// <summary>
		/// Three-letter ISO currency code, in uppercase. Must be a supported currency.
		/// </summary>
		public string? Currency { get; set; }

		/// <summary>
		/// ID of the customer created in Crypto.com Pay Merchant Dashboard, if exists.
		/// </summary>
		[JsonPropertyName("customer_id")]
		public string? CustomerId { get; set; }

		/// <summary>
		/// The URL of the payment page which customers will navigate to in order to make the payment.
		/// </summary>
		[JsonPropertyName("payment_url")]
		public string? PaymentUrl { get; set; }

		/// <summary>
		/// The URL for payment page to redirect back to when the payment becomes succeeded.
		/// </summary>
		[JsonPropertyName("return_url")]
		public string? ReturnUrl { get; set; }

		/// <summary>
		/// The URL for payment page to redirect to when the payment is failed or cancelled.
		/// </summary>
		[JsonPropertyName("cancel_url")]
		public string? CancelUrl { get; set; }

		/// <summary>
		/// An arbitrary string attached to the object.
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Has the value true if the object exists in live mode or the value false if the object exists in test mode.
		/// </summary>
		[JsonPropertyName("live_mode")]
		public bool? LiveMode { get; set; }

		/// <summary>
		/// Set of key-value pairs that you can attach to an object. This can be useful for storing additional information about the object in a structured format.
		/// </summary>
		public Dictionary<string, string>? Metadata { get; set; }

		/// <summary>
		/// Merchant provided order ID for this payment.
		/// </summary>
		[JsonPropertyName("order_id")]
		public string? OrderId { get; set; }

		/// <summary>
		/// The name of the merchant collecting this payment.
		/// </summary>
		public string? Recipient { get; set; }

		/// <summary>
		/// Whether the charge has been fully refunded. If the charge is only partially refunded, this attribute will still be false.
		/// </summary>
		public bool? Refunded { get; set; }

		/// <summary>
		/// The status of the payment is either pending (pending payment), succeeded (payment captured), or cancelled.
		/// </summary>
		public string? Status { get; set; }

		/// <summary>
		/// Whether the payment is paid from Crypto.com Wallet App or External Wallets.
		/// </summary>
		[JsonPropertyName("payment_source")]
		public string? PaymentSource { get; set; }

		/// <summary>
		/// Whether the payment is about checkout or invoice.
		/// </summary>
		[JsonPropertyName("payment_type")]
		public string? PaymentType { get; set; }
	}
}