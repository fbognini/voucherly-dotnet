namespace Voucherly.Sdk.Models.Payments
{
    public enum PaymentStaus : short
    {
        Requested = -1,
        Paid = 0,
        Confirmed = 1,
        Refunded = 2,
        Cancelled = 99,
        Voided = 101,
        Expired = 102
    }
}
