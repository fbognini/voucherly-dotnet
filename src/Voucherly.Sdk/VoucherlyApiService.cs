using fbognini.Sdk;
using fbognini.Sdk.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using Voucherly.Sdk.Endpoints;
using Voucherly.Sdk.Models.Customers;
using Voucherly.Sdk.Models.PaymentGateways;
using Voucherly.Sdk.Models.PaymentMethods;
using Voucherly.Sdk.Models.Payments;
using Voucherly.Sdk.Requests;

namespace Voucherly.Sdk
{
    public interface IVoucherlyApiService
    {

        static JsonSerializerOptions JsonSerializerOptions => new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        #region Payments
        Task<Payment> CreatePayment(CreatePaymentRequest request);
        Task<Payment> ConfirmPayment(string id);
        Task<Payment> GetPayment(string id, GetPaymentRequest request);
        Task<Payment> RefundPayment(string id);

        #endregion

        #region Customer

        Task<PaginationResponse<PaymentMethod>> GetCustomerPaymentMethods(string id);
        Task DeletePaymentMethod(string customerId, string id);

        #endregion

        #region Payment Gateways
        Task<PaymentGatewaysResponse> GetPaymentGateways(GetPaymentGatewaysRequest request);
        #endregion
    }

    internal class VoucherlyApiService : BaseApiService, IVoucherlyApiService
    {
        private VoucherlyApiSettings settings;

        public VoucherlyApiService(HttpClient client, IOptions<VoucherlyApiSettings> options)
            : base(client, options: IVoucherlyApiService.JsonSerializerOptions)
        {
            settings = options.Value;

            this.client.BaseAddress = new Uri("https://api.voucherly.it/");
            this.client.DefaultRequestHeaders.Add("Voucherly-API-Key", settings.ApiKey);
        }

        public async Task<Payment> GetPayment(string id, GetPaymentRequest request)
        {
            var options = new RequestOptions();
            if (request.VoucherlyWaitTime.HasValue)
            {
                options.Headers.Add("Voucherly-Wait-Time", request.VoucherlyWaitTime.Value.ToString());
            }

            return await GetApiAsync<Payment>(PaymentEndpoints.GetPayment(id, request?.Includes ?? Enumerable.Empty<PaymentIncludes>()));
        }

        public async Task<Payment> CreatePayment(CreatePaymentRequest request)
        {
            return await PostApiAsync<Payment, CreatePaymentRequest>(PaymentEndpoints.CreatePayment(), request);
        }

        public async Task<Payment> ConfirmPayment(string id)
        {
            return await PostApiAsync<Payment>(PaymentEndpoints.ConfirmPayment(id));
        }

        public async Task<Payment> RefundPayment(string id)
        {
            return await PostApiAsync<Payment>(PaymentEndpoints.RefundPayment(id));
        }

        public async Task<PaginationResponse<PaymentMethod>> GetCustomerPaymentMethods(string id)
        {
            return await GetApiAsync<PaginationResponse<PaymentMethod>>(CustomerEndpoints.GetPaymentMethods(id));
        }

        public async Task DeletePaymentMethod(string customerId, string id)
        {
            await DeleteApiAsync(CustomerEndpoints.DeletePaymentMethod(customerId, id));
        }

        public async Task<PaymentGatewaysResponse> GetPaymentGateways(GetPaymentGatewaysRequest request)
        {
            return await GetApiAsync<PaymentGatewaysResponse>(PaymentGatewayEndpoints.GetPaymentGateways(request.All, request.Includes ?? Enumerable.Empty<PaymentGatewayIncludes>()));
        }
    }
}