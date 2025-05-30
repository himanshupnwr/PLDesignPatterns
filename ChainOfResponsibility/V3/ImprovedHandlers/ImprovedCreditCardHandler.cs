using ChainOfResponsibility.V3.Model;
using ChainOfResponsibility.V3.Processors;

namespace ChainOfResponsibility.V3.ImprovedHandlers
{
    internal class ImprovedCreditCardHandler : IReceiver<Order>
    {
        public CreditCardPaymentProcessor CreditCardPaymentProcessor { get; }
            = new CreditCardPaymentProcessor();

        public void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.CreditCard))
            {
                CreditCardPaymentProcessor.Finalize(order);
            }
        }
    }
}
