using ChainOfResponsibility.V3.Exceptions;
using ChainOfResponsibility.V3.Model;

namespace ChainOfResponsibility.V3.Handler
{
    public abstract class PaymentHandler : IHandler<Order>
    {
        private IHandler<Order> Next { get; set; }
        public virtual void Handle(Order order)
        {
            Console.WriteLine($"Running: {GetType().Name}");

            if (Next == null && order.AmountDue > 0)
            {
                throw new InsufficientPaymentException();
            }

            if (order.AmountDue > 0) {
                Next.Handle(order);
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }
        }

        public IHandler<Order> SetNext(IHandler<Order> next)
        {
            Next = next;
            return Next;
        }
    }
}
