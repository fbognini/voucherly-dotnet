using Voucherly.Sdk.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucherly.Sdk.Endpoints
{
    internal static class PaymentEndpoints
    {
        private const string Endpoint = "payments";

        public static string GetPayment(string id, IEnumerable<PaymentIncludes> includes) => $"v1/{Endpoint}/{id}" +
            $"?{string.Join('&', includes.Select(x => $"include={x}"))}";
        public static string CreatePayment() => $"v1/{Endpoint}";
        public static string ConfirmPayment(string id) => $"v1/{Endpoint}/{id}/confirm";
        public static string RefundPayment(string id) => $"v1/{Endpoint}/{id}/refund";
    }
}
