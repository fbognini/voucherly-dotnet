using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Voucherly.Sdk.Models.PaymentMethods;

namespace Voucherly.Sdk.Models.Payments
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string PaymentGatewayId { get; set; } = string.Empty;
        public string ExternalId1 { get; set; } = string.Empty;
        public string ExternalId2 { get; set; } = string.Empty;
        public string ExternalId3 { get; set; } = string.Empty;
        public bool IsWallet { get; set; }
        public long Amount { get; set; }
        public long VoucherAmount { get; set; }
        public int? NoOfVouchers { get; set; }
        public long ConfirmedAmount { get; set; }
        public long RefundedAmount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string? CustomerPaymentMethodId { get; set; }
        public CreditCardInfo? CreditCard { get; set; }
        public DirectDebitInfo? DirectDebit { get; set; }
        public string? HolderEmail { get; set; }
        public string? HolderName { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
