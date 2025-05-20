namespace Facade.V2
{
    public class Program
    {
        static void Main(string[] args)
        {
            BigClassFacade facade = new BigClassFacade();
            facade.IncreaseBy(50);
            facade.DecreaseBy(20);

            Console.WriteLine($"Final Number : { facade.GetCurrentValue()}");

            //Calling Generic Facade
            const string zipCode = "98074";
            IWeatherFacade weatherFacade = new WeatherFacade();
            WeatherFacadeResults weatherFacadeResults = weatherFacade.GetTempInCity(zipCode);
        }
    }
}
