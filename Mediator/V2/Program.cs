namespace Mediator.V2
{
    public class Program
    {
        static void Main(string[] args) {   
            var mediator = new ConcreteMediator();
            var c1 = mediator.CreateColleague<Colleague1>();
            var c2 = mediator.CreateColleague<Colleague2>();

            c1.Send("Hello, World! (from c1)");
            c2.Send("h1, there! (from c2)");
        }
    }
}
