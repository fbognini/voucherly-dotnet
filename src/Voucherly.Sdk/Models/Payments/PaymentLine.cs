using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Voucherly.Sdk.Models.Payments
{
    public class PaymentLine
    {
        public int Quantity { get; set; }
        public long UnitAmount { get; set; }
        public long UnitDiscountAmount { get; set; }
        /// <summary>
        /// cumulative discount for line. can be used if UnitDiscountAmount is zero
        /// </summary>
        public long DiscountAmount { get; set; }
        /// <summary>
        /// UnitAmount * Quantity
        /// </summary>
        public long TotalAmount { get; set; }
        /// <summary>
        /// UnitDiscountAmount * Quantity
        /// </summary>
        public long TotalDiscountAmount { get; set; }
        /// <summary>
        /// TotalAmount - TotalDiscountAmount - DiscountAmount
        /// </summary>
        public long FinalAmount { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public bool IsFood { get; set; }
    }
}
