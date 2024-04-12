using FactoryMethod.SimpleFactory.Models.Commerce.Invoice;
using FactoryMethod.SimpleFactory.Models.Commerce.Summary;
using FactoryMethod.SimpleFactory.Models.Commerce;
using FactoryMethod.SimpleFactory.Models.Shipping.Factories;
using FactoryMethod.SimpleFactory.Models.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.SimpleFactory
{
    public class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }
}
