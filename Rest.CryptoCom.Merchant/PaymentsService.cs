using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Rest.CryptoCom.Merchant.Abstractions;
using Rest.CryptoCom.Merchant.Requests;
using Rest.CryptoCom.Merchant.Responses;
using Rest.CryptoCom.Merchant.ServiceModel;

namespace Rest.CryptoCom.Merchant
{
	public class PaymentsService : BaseService, IPaymentsService
	{
		public PaymentsService(ICryptoComConfig config)
			: base(config)
		{
		}

		public PaymentsService(ICryptoComConfig config, IHttpClientFactory httpClientFactory)
			: base(config, httpClientFactory)
		{
		}

		public async Task<Payment?> CreateAsync(
			CreatePaymentRequest request,
			CancellationToken token = default)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			using var httpClient = this.HttpClient;
			using var httpRequestMessage = CreateRequest(request, HttpMethod.Post, new Uri(this.BaseUri, "payments"));

			using var response = await httpClient.SendAsync(httpRequestMessage, token);
			using var stream = await response.Content.ReadAsStreamAsync();

			var result = await JsonSerializer.DeserializeAsync<Payment>(stream, this.JsonSerializerOptions, token);
			return result;
		}

		public async Task<Payment?> GetAsync(string paymentId, CancellationToken token = default)
		{
			if (paymentId is null)
			{
				throw new ArgumentNullException(nameof(paymentId));
			}

			if (string.IsNullOrWhiteSpace(paymentId))
			{
				throw new ArgumentException(nameof(paymentId));
			}

			var uri = new Uri(this.BaseUri, $"payments/{paymentId}");

			using var httpClient = this.HttpClient;
			using var stream = await httpClient.GetStreamAsync(uri);

			var result = await JsonSerializer.DeserializeAsync<Payment>(stream, this.JsonSerializerOptions, token);
			return result;
		}

		public async Task<ListPaymentsResponse?> ListAsync(
			ListPaymentsRequest request,
			CancellationToken token = default)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			var uriBuilder = UriHelper.BuildQuery(request, new(this.BaseUri, "payments"));

			using var httpClient = this.HttpClient;
			using var stream = await httpClient.GetStreamAsync(uriBuilder.ToString());

			var result = await JsonSerializer.DeserializeAsync<ListPaymentsResponse>(stream, this.JsonSerializerOptions, token);
			return result;
		}

		public async Task<Payment?> CancelAsync(string paymentId, CancellationToken token = default)
		{
			if (paymentId is null)
			{
				throw new ArgumentNullException(nameof(paymentId));
			}

			if (string.IsNullOrWhiteSpace(paymentId))
			{
				throw new ArgumentException(nameof(paymentId));
			}

			var uri = new Uri(this.BaseUri, $"payments/{paymentId}/cancel");

			using var httpClient = this.HttpClient;
			using var response = await httpClient.SendAsync(new(HttpMethod.Post, uri), token);
			using var stream = await response.Content.ReadAsStreamAsync();

			var result = await JsonSerializer.DeserializeAsync<Payment>(stream, this.JsonSerializerOptions, token);
			return result;
		}
	}
}