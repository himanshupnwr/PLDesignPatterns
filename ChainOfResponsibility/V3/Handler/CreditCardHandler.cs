using ChainOfResponsibility.V3.Model;
using ChainOfResponsibility.V3.Processors;

namespace ChainOfResponsibility.V3.Handler
{
    public class CreditCardHandler : PaymentHandler
    {
        public CreditCardPaymentProcessor creditCardPaymentProcessor { get; } = new CreditCardPaymentProcessor();

        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard)) { 
                creditCardPaymentProcessor.Finalize(order);
            }
            base.Handle(order);
        }
    }
}
