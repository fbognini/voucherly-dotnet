using System.Text.Json.Serialization;

namespace Voucherly.Sdk.Models.Customers;

public class CustomerWalletRow
{
    public string CustomerId { get; set; } = string.Empty;
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CustomerWalletRowAction Action { get; set; }
    public Guid? TransactionId { get; set; }
    public string? PaymentId { get; set; }
    public string? PaymentGatewayId { get; set; }

    public int Amount { get; set; }
    public int VoucherAmount { get; set; }
    public long? RunningTotalAmount { get; set; }
    public long? RunningTotalVoucherAmount { get; set; }
    public DateTime OccurredOnUtc { get; set; }
}
