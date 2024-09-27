using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Voucherly.Sdk.Endpoints
{
    internal static class CustomerEndpoints
    {
        private const string Endpoint = "customers";

        public static string GetPaymentMethods(string id) => $"v1/{Endpoint}/{id}/payment-methods";

        public static string DeletePaymentMethod(string customerId, string id) => $"v1/{Endpoint}/{customerId}/payment-methods/{id}";

        public static string GetWalletMovements(List<string>? customerIds, DateTime? fromUtc, DateTime? toUtc, int? page, int? length)
        {
            var sb = new StringBuilder($"v1/{Endpoint}/wallet/movements");
            var queryStringBuilder = new StringBuilder();
            if (customerIds?.Any() == true)
            {
                queryStringBuilder.Append(string.Join("&", customerIds.Select(ci => $"customerId={ci}")));
            }
            if (fromUtc != null)
            {
                queryStringBuilder.Append($"&fromUtc={fromUtc?.ToString("s")}");
            }
            if (toUtc != null)
            {
                queryStringBuilder.Append($"&toUtc={toUtc?.ToString("s")}");
            }
            if (page != null)
            {
                queryStringBuilder.Append($"&page={page}");
            }
            if (length != null)
            {
                queryStringBuilder.Append($"&length={length}");
            }

            if (queryStringBuilder.Length > 0)
            {
                if (queryStringBuilder[0] == '&')
                {
                    queryStringBuilder.Remove(0, 1);
                }
                sb.Append("?")
                    .Append(queryStringBuilder);
            }

            return sb.ToString();
        }
    }
}
