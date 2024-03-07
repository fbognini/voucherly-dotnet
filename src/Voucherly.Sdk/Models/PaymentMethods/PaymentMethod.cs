namespace Voucherly.Sdk.Models.PaymentMethods
{
    public class PaymentMethod
    {
        public string Id { get; set; }
        public string PaymentGatewayId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Pan { get; set; }
        public string? PanExpiration { get; set; }
    }
}
