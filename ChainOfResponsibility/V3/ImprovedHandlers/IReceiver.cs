namespace ChainOfResponsibility.V3.ImprovedHandlers
{
    public interface IReceiver<T> where T : class
    {
        void Handle(T request);
    }
}
