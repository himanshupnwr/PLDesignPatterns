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
    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            if (order.Recipient.Country != order.Sender.Country)
            {
                return new NoVATInvoice();
            }

            return new VATInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;

            if (order.Sender.Country != order.Recipient.Country)
            {
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            }
            else
            {
                shippingProviderFactory = new StandardShippingProviderFactory();
            }

            return shippingProviderFactory.GetShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            // Translate email to Swedish
            return new EmailSummary();
        }
    }
}
