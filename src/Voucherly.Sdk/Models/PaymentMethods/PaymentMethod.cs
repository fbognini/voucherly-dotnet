namespace Voucherly.Sdk.Models.PaymentMethods
{
    public class PaymentMethod
    {
        public string Id { get; set; } = string.Empty;
        public string PaymentGatewayId { get; set; } = string.Empty;

        public string HolderEmail { get; set; } = string.Empty;
        public string HolderName { get; set; } = string.Empty;

        public CreditCardInfo? CreditCard { get; set; }
        public DirectDebitInfo? DirectDebit { get; set; }
    }

    public class CreditCardInfo
    {
        public string Brand { get; set; } = string.Empty;
        public string Pan { get; set; } = string.Empty;
        public string Expiration { get; set; } = string.Empty;
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string? Product { get; set; } = string.Empty;
    }

    public class DirectDebitInfo
    {
        public string AccountId { get; set; } = string.Empty;
        public string AccountBic { get; set; } = string.Empty;
        public string AccountIban { get; set; } = string.Empty;
    }
}
