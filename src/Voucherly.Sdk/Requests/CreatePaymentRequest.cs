using Voucherly.Sdk.Models.Payments;
using System.Text.Json.Serialization;

namespace Voucherly.Sdk.Requests
{
    public class CreatePaymentRequest
    {
        public class PaymentLine
        {
            public int Quantity { get; set; }
            public int? PriceId { get; set; }
            public long UnitAmount { get; set; }
            public long UnitDiscountAmount { get; set; }
            public long DiscountAmount { get; set; }
            public double? TaxRate { get; set; }
            public int? ProductId { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public string ProductDescription { get; set; } = string.Empty;
            public string ProductImage { get; set; } = string.Empty;
            public bool IsFood { get; set; }
        }

        public class PaymentDiscount
        {
            public string DiscountName { get; set; } = string.Empty;
            public string DiscountDescription { get; set; } = string.Empty;
            public long? Amount { get; set; }
            public DiscountType? Type { get; set; }
            public long? Value { get; set; }
            /// <summary>
            /// if not null, the discount is applied to the amount discounted through the previous discounts
            /// </summary>
            public int? Index { get; set; }
        }

        public PaymentMode Mode { get; set; }
        public string? ReferenceId { get; set; }
        public int? Timeout { get; set; }
        public string? CustomerPaymentMethodId { get; set; }
        public string? CustomerId { get; set; }
        public string CustomerFirstName { get; set; } = default!;
        public string CustomerLastName { get; set; } = default!;
        public string CustomerEmail { get; set; } = default!;
        public bool? IsPartialPayment { get; set; }
        public bool? IsAutoConfirm { get; set; }
        public string? SelectedPaymentGateway { get; set; }
        public List<string> PaymentGateways { get; set; } = new();
        public string RedirectOkUrl { get; set; } = string.Empty;
        public string RedirectKoUrl { get; set; } = string.Empty;
        public string? CallbackUrl { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? ShippingAddress { get; set; }
        public Dictionary<string, string>? Metadata { get; set; }
        public List<PaymentLine> Lines { get; set; } = new();
        public List<PaymentDiscount> Discounts { get; set; } = new();
    }
}