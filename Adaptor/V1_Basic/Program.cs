namespace Adaptor.V1_Basic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Adapter";

            // object adapter example
            ICityAdapter adapter = new CityAdapter();
            var city = adapter.GetCity();

            Console.WriteLine($"{city.FullName}, {city.Inhabitants}");
            Console.ReadKey();
        }
    }
}
