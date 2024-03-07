using Voucherly.Sdk.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucherly.Sdk.Requests
{
    public class GetPaymentRequest
    {
        public List<PaymentIncludes>? Includes { get; set; }
        public int? VoucherlyWaitTime { get; set; }
    }
}
