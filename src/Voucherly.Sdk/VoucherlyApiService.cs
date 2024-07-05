using fbognini.Sdk;
using fbognini.Sdk.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using Voucherly.Sdk.Endpoints;
using Voucherly.Sdk.Models.PaymentGateways;
using Voucherly.Sdk.Models.PaymentMethods;
using Voucherly.Sdk.Models.Payments;
using Voucherly.Sdk.Requests;

namespace Voucherly.Sdk
{
    public interface IVoucherlyApiService
    {
        #region Payments
        Task<Payment> CreatePayment(CreatePaymentRequest request);
        Task<Payment> ConfirmPayment(string id);
        Task<Payment> GetPayment(string id, GetPaymentRequest request);
        Task<Payment> RefundPayment(string id);

        #endregion

        #region Customer

        Task<List<PaymentMethod>> GetCustomerPaymentMethods(string id);
        Task DeletePaymentMethod(string customerId, string id);

        #endregion

        #region Payment Gateways
        Task<PaymentGatewaysResponse> GetPaymentGateways(GetPaymentGatewaysRequest request);
        #endregion
    }

    internal class VoucherlyApiService : BaseApiService, IVoucherlyApiService
    {
        private InternalVoucherlyApiSettings settings;

        public VoucherlyApiService(HttpClient client, ILogger<VoucherlyApiService> logger, IOptions<InternalVoucherlyApiSettings> options)
            : base(client, logger, options: new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() },
            })
        {
            settings = options.Value;
            ChangeSettings(settings);
        }

        private void ChangeSettings(InternalVoucherlyApiSettings settings)
        {
            if (settings is null)
            {
                return;
            }

            client.BaseAddress = new Uri("https://api.voucherly.it/");
            client.DefaultRequestHeaders.Add("Voucherly-API-Key", settings.ApiKey);

            this.settings = settings;
        }

        public async Task<Payment> GetPayment(string id, GetPaymentRequest request)
        {
            var options = new RequestOptions();
            if (request.VoucherlyWaitTime.HasValue)
            {
                options.Headers.Add("Voucherly-Wait-Time", request.VoucherlyWaitTime.Value.ToString());
            }

            return await GetApi<Payment>(PaymentEndpoints.GetPayment(id, request?.Includes ?? Enumerable.Empty<PaymentIncludes>()));
        }

        public async Task<Payment> CreatePayment(CreatePaymentRequest request)
        {
            return await PostApi<Payment, CreatePaymentRequest>(PaymentEndpoints.CreatePayment(), request);
        }

        public async Task<Payment> ConfirmPayment(string id)
        {
            return await PostApi<Payment>(PaymentEndpoints.ConfirmPayment(id));
        }

        public async Task<Payment> RefundPayment(string id)
        {
            return await PostApi<Payment>(PaymentEndpoints.RefundPayment(id));
        }

        public async Task<List<PaymentMethod>> GetCustomerPaymentMethods(string id)
        {
            return await GetApi<List<PaymentMethod>>(CustomerEndpoints.GetPaymentMethods(id));
        }

        public async Task DeletePaymentMethod(string customerId, string id)
        {
            await DeleteApi(CustomerEndpoints.DeletePaymentMethod(customerId, id));
        }

        public async Task<PaymentGatewaysResponse> GetPaymentGateways(GetPaymentGatewaysRequest request)
        {
            return await GetApi<PaymentGatewaysResponse>(PaymentGatewayEndpoints.GetPaymentGateways(request.All, request.Includes ?? Enumerable.Empty<PaymentGatewayIncludes>()));
        }
    }
}