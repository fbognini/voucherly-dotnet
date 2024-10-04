using Voucherly.Sdk.Models.PaymentGateways;

namespace Voucherly.Sdk.Requests
{
    public class GetCustomerWalletMovementsRequest
    {
        public List<string>? CustomerIds { get; set; }
        public DateTime? FromUtc { get; set; }
        public DateTime? ToUtc { get; set; }
        public int? Page { get; set; }
        public int? Length { get; set; }
    }
}
