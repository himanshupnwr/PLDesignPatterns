using FactoryMethod.SimpleFactory.Models.Commerce.Invoice;
using FactoryMethod.SimpleFactory.Models.Commerce.Summary;
using FactoryMethod.SimpleFactory.Models.Commerce;
using FactoryMethod.SimpleFactory.Models.Shipping;

namespace FactoryMethod.SimpleFactory
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CreateShippingProvider(Order order);
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
    }
}
