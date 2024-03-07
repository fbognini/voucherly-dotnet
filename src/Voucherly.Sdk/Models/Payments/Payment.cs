using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Voucherly.Sdk.Models.Payments
{
    public class Payment
    {
        public string Id { get; set; } = string.Empty;
        public string? ReferenceId { get; set; }
        public PaymentMode Mode { get; set; }
        public string? ParentPaymentId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public string CustomerFirstName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string? SelectedPaymentGateway { get; set; }
        public List<string> PaymentGateways { get; set; } = new();
        public string? CheckoutUrl { get; set; }
        public string RedirectSuccessUrl { get; set; } = string.Empty;
        public string RedirectErrorUrl { get; set; } = string.Empty;
        public string? RedirectUrl { get; set; }
        public string? S2SUrl { get; set; }
        public long TotalAmount { get; set; }
        public long DiscountAmount { get; set; }
        public long FinalAmount { get; set; }
        public long PaidAmount { get; set; }
        public long PaidVoucherAmount { get; set; }
        public long Amount { get; set; }
        public bool HasWallet { get; set; }
        public PaymentStaus Status { get; set; }


        public List<PaymentLine>? Lines { get; set; }
        public List<PaymentDiscount>? Discounts { get; set; }
        public List<Transaction>? Transactions { get; set; }

    }
}
