using System.Collections.Generic;
using System.Text.Json.Serialization;
using Rest.CryptoCom.Merchant.ServiceModel;

namespace Rest.CryptoCom.Merchant.Responses
{
	public class ListPaymentsResponse
	{
		[JsonPropertyName("items")]
		public List<Payment>? Payments { get; set; }

		public Metadata? Meta { get; set; }
	}
}