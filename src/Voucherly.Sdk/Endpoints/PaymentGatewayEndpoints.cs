using Voucherly.Sdk.Models.PaymentGateways;

namespace Voucherly.Sdk.Endpoints
{
    internal static class PaymentGatewayEndpoints
    {
        private const string Endpoint = "payment_gateways";

        public static string GetPaymentGateways(bool? all, IEnumerable<PaymentGatewayIncludes> includes) => $"v1/{Endpoint}" +
            $"?all={all}&{string.Join('&', includes.Select(x => $"include={x}"))}";
    }
}
