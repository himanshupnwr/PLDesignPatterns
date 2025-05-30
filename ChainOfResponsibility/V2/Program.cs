using ChainOfResponsibility.V2.Model;

namespace ChainOfResponsibility.V2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Filip Ekberg", 
                "870101XXXX", 
                new System.Globalization.RegionInfo("SE"), 
                new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));

            var processor = new UserProcessor();
            var result = processor.Register(user);
            Console.WriteLine(result);
        }
    }
}
