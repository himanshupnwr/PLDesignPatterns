using ChainOfResponsibility.V3.Model;
using ChainOfResponsibility.V3.Processors;

namespace ChainOfResponsibility.V3.Handler
{
    public class PaypalHandler : PaymentHandler
    {
        private PaypalPaymentProcessor PaypalPaymentProcessor { get; }
            = new PaypalPaymentProcessor();

        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Paypal))
            {
                PaypalPaymentProcessor.Finalize(order);
            }

            base.Handle(order);
        }
    }
}
