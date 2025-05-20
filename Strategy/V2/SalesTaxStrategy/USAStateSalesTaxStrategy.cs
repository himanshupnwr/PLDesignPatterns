using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.V2.SalesTaxStrategy
{
    public class USAStateSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            var totalPrice = order.TotalPrice;

            switch (order.ShippingDetails.DestinationState.ToLowerInvariant())
            {
                case "la": return totalPrice * 0.095m;
                case "ny": return totalPrice * 0.04m;
                case "nyc": return totalPrice * 0.045m;
                default: return 0m;
            }
        }
    }
}
