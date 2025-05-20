namespace DecoratorPatternExample.WeatherInterface
{
    public interface IWeatherService
    {
        CurrentWeather GetCurrentWeather(string location);
        LocationForecast GetForecast(string location);

    }
}
