namespace Voucherly.Sdk.Models.PaymentGateways
{
    public class MerchantPaymentGateway
    {
        public string? DefaultPaymentGatewayId { get; set; }
        public bool IsFallback { get; set; }
    }
}
