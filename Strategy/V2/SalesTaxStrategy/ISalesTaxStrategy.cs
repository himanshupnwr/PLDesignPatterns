using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.V2.SalesTaxStrategy
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
