using Moq;
using NUnit.Framework;
using Rest.CryptoCom.Merchant.Abstractions;

namespace Rest.CryptoCom.Merchant.Tests
{
	public abstract class BaseServiceTests<TService>
	{
		protected abstract TService GetService();

		protected TService? Service { get; private set; }

		protected Mock<ICryptoComConfig>? ConfigMock { get; private set; }

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this.ConfigMock = new();
			this.ConfigMock
				.Setup(x => x.CryptoComPublicKey)
				.Returns("pk_test_N1V7zTfWrvzrEFwP124ox46h");

			this.ConfigMock
				.Setup(x => x.CryptoComSecretKey)
				.Returns("sk_test_oVNY1PLa6f5Wfkj3EEAXX7s4");
		}

		[SetUp]
		public void SetUp()
		{
			this.Service = GetService();
		}
	}
}