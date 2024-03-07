using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Voucherly.Sdk.Models.Payments
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string PaymentGatewayId { get; set; }
        public string ExternalId1 { get; set; }
        public string ExternalId2 { get; set; }
        public string ExternalId3 { get; set; }
        public bool IsWallet { get; set; }
        public long Amount { get; set; }
        public long VoucherAmount { get; set; }
        public int? NoOfVouchers { get; set; }
        public long ConfirmedAmount { get; set; }
        public long RefundedAmount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Pan { get; set; } = string.Empty;
        public string? PanExpiration { get; set; }
        public string Status { get; set; }
    }
}
