﻿using DecoratorPatternExample.WeatherInterface;
using System.Diagnostics;

namespace DecoratorPatternExample.Decorators
{
    public class WeatherServiceLoggingDecorator : IWeatherService
    {
        public WeatherServiceLoggingDecorator(IWeatherService weatherService, ILogger<WeatherServiceLoggingDecorator> logger)
        {
            _innerWeatherService = weatherService;
            _logger = logger;
        }


        private IWeatherService _innerWeatherService;
        private ILogger<WeatherServiceLoggingDecorator> _logger;

        public CurrentWeather GetCurrentWeather(string location)
        {
            var sw = Stopwatch.StartNew();
            var currentWeather = _innerWeatherService.GetCurrentWeather(location);
            sw.Stop();
            var elapsedMillis = sw.ElapsedMilliseconds;
            _logger.LogWarning("Retrieved weather data for {location} - Elapsed ms: {} {@currentWeather}", location, elapsedMillis, currentWeather);

            return currentWeather;
        }

        public LocationForecast GetForecast(string location)
        {
            return _innerWeatherService.GetForecast(location);
        }
    }
}