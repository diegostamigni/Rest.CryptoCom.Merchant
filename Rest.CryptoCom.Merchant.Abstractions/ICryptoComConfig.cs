namespace Rest.CryptoCom.Merchant.Abstractions
{
	public interface ICryptoComConfig
	{
		public string? CryptoComPublicKey { get; set; }

		public string? CryptoComSecretKey { get; set; }

		public string? CryptoComWebhookSecret { get; set; }
	}
}