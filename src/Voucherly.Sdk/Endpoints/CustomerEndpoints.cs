using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucherly.Sdk.Endpoints
{
    internal static class CustomerEndpoints
    {
        private const string Endpoint = "customers";

        public static string GetPaymentMethods(string id) => $"v1/{Endpoint}/{id}/payment-methods";

        public static string DeletePaymentMethod(string customerId, string id) => $"v1/{Endpoint}/{customerId}/payment-methods/{id}";
    }
}
