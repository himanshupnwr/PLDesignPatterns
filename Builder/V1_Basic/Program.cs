using static Builder.V1_Basic.Implementation;

namespace Builder.V1_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Builder";

            var garage = new Garage();

            var miniBuilder = new MiniBuilder();
            var bmwBuilder = new BMWBuilder();

            garage.Construct(miniBuilder);
            Console.WriteLine(miniBuilder.Car.ToString());
            // or: 
            garage.Show();

            garage.Construct(bmwBuilder);
            Console.WriteLine(bmwBuilder.Car.ToString());
            // or: 
            garage.Show();

            Console.ReadKey();
        }
    }
}
