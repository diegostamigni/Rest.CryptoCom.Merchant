using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rest.CryptoCom.Merchant.Requests;
using Rest.CryptoCom.Merchant.Responses;
using Rest.CryptoCom.Merchant.ServiceModel;

namespace Rest.CryptoCom.Merchant.Abstractions
{
	public interface IPaymentsService
	{
		/// <summary>
		/// To accept a crypto payment, you need to create a Payment object. If your API keys is in test mode,
		/// no crypto is actually accepted, although everything else will occur as if in live mode.
		/// (Crypto.com Pay assumes that the payment would have completed successfully in test mode).
		/// </summary>
		/// <param name="request">The create payment request</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Returns the payment object if the creation succeeded. This call will return an error if something goes wrong.</returns>
		Task<Payment?> CreateAsync(CreatePaymentRequest request, CancellationToken token = default);

		/// <summary>
		/// Retrieves the details of a payment that has previously been created. Supply the unique payment ID that was
		/// returned from your previous request, and the API will return the corresponding payment information.
		/// </summary>
		/// <param name="paymentId">The identifier of the payment to be retrieved.</param>
		/// <param name="token">Cancellation token</param>
		/// <returns>Returns a payment if a valid identifier was provided, and returns an error otherwise.</returns>
		Task<Payment?> GetAsync(string paymentId, CancellationToken token = default);

		/// <summary>
		/// Returns a list of payments you’ve previously created. The payments are returned in sorted order,
		/// with the most recent payment appearing first. You can optionally provide parameters to filter out the results.
		/// </summary>
		/// <param name="request">The get payments request</param>
		/// <param name="token">Cancellation token</param>
		/// <returns></returns>
		Task<ListPaymentsResponse?> ListAsync(ListPaymentsRequest request, CancellationToken token = default);

		/// <summary>
		/// Cancels a payment indicates that you do not want the payment to go through anymore.
		/// The status of payment will change from pending to cancelled. Cancelling a payment is irreversible.
		/// Approved payments can't be cancelled.
		/// </summary>
		/// <param name="paymentId">The identifier of the payment to be cancelled.</param>
		/// <param name="token">Cancellation token</param>
		/// <returns></returns>
		Task<Payment?> CancelAsync(string paymentId, CancellationToken token = default);
	}
}