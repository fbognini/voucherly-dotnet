using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucherly.Sdk.Models.Payments
{
    public enum DiscountType : short
    {
        DOLLAROFF = 1,
        PERCENOFF = 2,
        FIXED = 3,
    }
}
