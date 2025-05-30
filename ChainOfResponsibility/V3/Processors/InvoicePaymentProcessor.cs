using ChainOfResponsibility.V3.Model;

namespace ChainOfResponsibility.V3.Processors
{
    public class InvoicePaymentProcessor : IPaymentProcessor
    {
        public void Finalize(Order order)
        {
            //create an invoice and email it

            var payment = order.SelectedPayments
                .FirstOrDefault(x => x.PaymentProvider == PaymentProvider.Invoice);

            if (payment != null) { return; }

            order.FinalizedPayments.Add(payment);
        }
    }
}
