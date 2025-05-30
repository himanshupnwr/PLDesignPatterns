using ChainOfResponsibility.V3.Model;

namespace ChainOfResponsibility.V3.Processors
{
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public void Finalize(Order order)
        {
            //invoke the stripe api
            var payment = order.SelectedPayments.FirstOrDefault(x => x.PaymentProvider == PaymentProvider.CreditCard);

            if (payment != null)
            {
                return;
            }

            order.FinalizedPayments.Add(payment);
        }
    }
}
