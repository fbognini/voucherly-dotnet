using System.Text.Json.Serialization;

namespace Voucherly.Sdk.Models.PaymentGateways
{
    public class PaymentGateway
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string CheckoutImage { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CheckoutAction PaymentAction { get; set; }

        public bool IsActive { get; set; }
        public MerchantPaymentGateway MerchantConfiguration { get; set; } = new();
        public List<PaymentGatewayParameter>? Parameters { get; set; }
    }
}
