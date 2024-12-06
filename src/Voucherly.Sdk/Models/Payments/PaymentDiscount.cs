using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Voucherly.Sdk.Models.Payments
{
    public class PaymentDiscount
    {
        public string DiscountName { get; set; } = string.Empty;
        public string DiscountDescription { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string? Type { get; set; }
        public long? Value { get; set; }
        public int? Index { get; set; }
    }
}
