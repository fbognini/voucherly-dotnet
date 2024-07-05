using Voucherly.Sdk.Models.PaymentGateways;

namespace Voucherly.Sdk.Requests
{
    public class GetPaymentGatewaysRequest
    {
        public List<PaymentGatewayIncludes>? Includes { get; set; }
        public bool? All { get; set; }
    }
}
