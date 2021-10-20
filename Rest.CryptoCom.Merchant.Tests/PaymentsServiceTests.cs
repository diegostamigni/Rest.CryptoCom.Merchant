using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Rest.CryptoCom.Merchant.Abstractions;
using Rest.CryptoCom.Merchant.Requests;
using Shouldly;

namespace Rest.CryptoCom.Merchant.Tests
{
	[TestFixture]
	public class PaymentsServiceTests : BaseServiceTests<IPaymentsService>
	{
		[Test]
		public async Task CreatePayment_Success()
		{
			var request = new CreatePaymentRequest(10000, "USD")
			{
				Description = "A test payment",
				ReturnUrl = "https://www.example.com/suceeded",
				CancelUrl = "https://www.example.com/canceled",
				Metadata = new()
				{
					{ "internalInfo", Guid.NewGuid().ToString() }
				}
			};

			var result = await this.Service!.CreateAsync(request);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Id.ShouldNotBeNullOrEmpty(),
				() => result.Description.ShouldBe(request.Description),
				() => result.Amount.ShouldBe(request.Amount),
				() => result.Currency.ShouldBe(request.Currency),
				() => result.CryptoAmount.ShouldNotBeNullOrEmpty(),
				() => result.CryptoCurrency.ShouldNotBeNullOrEmpty(),
				() => result.Metadata.ShouldNotBeEmpty(),
				() => result.ReturnUrl.ShouldBe(request.ReturnUrl),
				() => result.CancelUrl.ShouldBe(request.CancelUrl)
			);
		}

		[TestCase("f12dc40b-56af-4e20-ba16-aa046410d0aa")]
		public async Task GetPayment_Success(string paymentId)
		{
			var result = await this.Service!.GetAsync(paymentId);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Id.ShouldBe(paymentId)
			);
		}

		[Test]
		public async Task GetPayments_Success()
		{
			var request = new ListPaymentsRequest();

			var result = await this.Service!.ListAsync(request);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Payments.ShouldNotBeEmpty()
			);
		}

		[Explicit]
		[TestCase("e24b52d7-cb2b-47ec-b0d3-e915123d7da0")]
		public async Task CancelPayment_Success(string paymentId)
		{
			var result = await this.Service!.CancelAsync(paymentId);
			result.ShouldNotBeNull();
			result.ShouldSatisfyAllConditions
			(
				() => result.Id.ShouldBe(paymentId),
				() => result.Status.ShouldBe("cancelled")
			);
		}

		protected override IPaymentsService GetService()
			=> new PaymentsService(this.ConfigMock!.Object);
	}
}