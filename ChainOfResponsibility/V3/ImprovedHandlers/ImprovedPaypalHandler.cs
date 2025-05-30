using ChainOfResponsibility.V3.Model;
using ChainOfResponsibility.V3.Processors;

namespace ChainOfResponsibility.V3.ImprovedHandlers
{
    public class ImprovedPaypalHandler : IReceiver<Order>
    {
        private PaypalPaymentProcessor PaypalPaymentProcessor { get; } = new PaypalPaymentProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Paypal))
            {
                PaypalPaymentProcessor.Finalize(order);
            }
        }
    }
}
