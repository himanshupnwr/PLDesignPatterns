using ChainOfResponsibility.V3.Model;
using ChainOfResponsibility.V3.Processors;

namespace ChainOfResponsibility.V3.ImprovedHandlers
{
    public class ImprovedInvoiceHandler : IReceiver<Order>
    {
        public InvoicePaymentProcessor InvoicePaymentProcessor { get; }
            = new InvoicePaymentProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice))
            {
                InvoicePaymentProcessor.Finalize(order);
            }
        }
    }
}
