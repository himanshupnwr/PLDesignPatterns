using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.V2.InvoiceStrategy
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}
