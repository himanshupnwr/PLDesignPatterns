using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.V2.InvoiceStrategy
{
    public abstract class InvoiceStrategy : IInvoiceStrategy
    {
        public abstract void Generate(Order order);

        //common functionality
        public string GenerateTextInvoice(Order order)
        {
            var invoice = $"INVOICE DATE: {DateTimeOffset.Now}{Environment.NewLine}{Environment.NewLine}";

            invoice += $"ID|NAME|PRICE|QUANTITY{Environment.NewLine}";

            foreach (var item in order.LineItems)
            {
                invoice += $"{item.Key.Id}|{item.Key.Name}|{item.Key.Price}|{item.Value}{Environment.NewLine}";
            }

            invoice += Environment.NewLine + Environment.NewLine;

            var tax = order.GetTax();
            var total = order.TotalPrice + tax;

            invoice += $"TAX TOTAL: {tax}{Environment.NewLine}";
            invoice += $"TOTAL: {total}{Environment.NewLine}";

            return invoice;
        }
    }
}
