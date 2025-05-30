using ChainOfResponsibility.V3.Model;

namespace ChainOfResponsibility.V3.Processors
{
    public interface IPaymentProcessor
    {
        void Finalize(Order order);
    }
}
