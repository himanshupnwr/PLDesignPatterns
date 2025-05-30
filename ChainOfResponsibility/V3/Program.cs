using ChainOfResponsibility.V3.Handler;
using ChainOfResponsibility.V3.ImprovedHandlers;
using ChainOfResponsibility.V3.Model;
namespace ChainOfResponsibility.V3
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            order.LineItems.Add(new Item("ATOMOSV", "Atomos Ninja V", 499), 2);
            order.LineItems.Add(new Item("EOSR", "Canon EOS R", 1799), 1);

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Paypal,
                Amount = 1000
            });

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice,
                Amount = 1797
            });

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);

            var handler = new PaypalHandler();
            handler.SetNext(new CreditCardHandler())
                .SetNext(new InvoiceHandler());

            //improved COR
            var improvedhandler = new ImprovedPaymentHandler(
                new ImprovedPaypalHandler(),
                new ImprovedInvoiceHandler(),
                new ImprovedCreditCardHandler()
            );

            handler.Handle(order);

            Console.WriteLine(order.AmountDue);
            Console.WriteLine(order.ShippingStatus);
        }
    }
}
