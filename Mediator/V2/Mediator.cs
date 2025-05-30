namespace Mediator.V2
{
    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }
}
