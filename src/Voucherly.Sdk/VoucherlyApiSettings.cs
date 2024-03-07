using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucherly.Sdk
{
    public class VoucherlyApiSettings
    {
        public string ApiKey { get; set; } = string.Empty;
    }

    internal class InternalVoucherlyApiSettings
    {
        public string ApiKey { get; set; } = string.Empty;
    }
}
