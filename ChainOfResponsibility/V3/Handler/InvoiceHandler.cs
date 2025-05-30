using ChainOfResponsibility.V3.Model;
using ChainOfResponsibility.V3.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.V3.Handler
{
    public class InvoiceHandler : PaymentHandler
    {
        public InvoicePaymentProcessor InvoicePaymentProcessor { get; } = new InvoicePaymentProcessor();

        public override void Handle(Order order)
        {
            if (order.SelectedPayments.Any(x => x.PaymentProvider == PaymentProvider.Invoice)) {
                InvoicePaymentProcessor.Finalize(order);
            }
            base.Handle(order);
        }
    }
}
