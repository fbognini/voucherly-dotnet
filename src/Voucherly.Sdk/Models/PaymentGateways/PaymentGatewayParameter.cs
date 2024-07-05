namespace Voucherly.Sdk.Models.PaymentGateways
{
    public class PaymentGatewayParameter
    {
        public string Id { get; set; } = string.Empty;
        public string FriendlyName { get; set; } = string.Empty;
        public bool IsSecret { get; set; }
        public string? Value { get; set; }
    }
}
