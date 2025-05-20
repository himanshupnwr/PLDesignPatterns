using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Facade.V2
{
    public interface IWeatherFacade
    {
        WeatherFacadeResults GetTempInCity(string zipCode);
    }

    public class WeatherFacade : IWeatherFacade
    {
        private readonly ConverterService _converteService;
        private readonly GeoLookupService _geoLookupService;
        private readonly WeatherService _weatherService;

        public WeatherFacade() : this(new ConverterService(), new GeoLookupService(), new WeatherService())
        {
            
        }

        public WeatherFacade(ConverterService converterService, GeoLookupService geoLoopupService, WeatherService weatherServive)
        {
            _converteService = converterService;
            _geoLookupService = geoLoopupService;
            _weatherService = weatherServive;
        }

        public WeatherFacadeResults GetTempInCity(string zipCode)
        {
            City city = _geoLookupService.GetCityForZipCode(zipCode);
            State state = _geoLookupService.GetStateForZipCode(zipCode);
            int tempF = _weatherService.GetTempFarenheit(city,state);
            int tempC = _converteService.ConvertFarenheitToCelcius(tempF);

            var results = new WeatherFacadeResults()
            {
                City = city,
                state = state,
                Farenheit = tempF,
                Celcius = tempC
            };

            return results;
        }
    }

    public class WeatherService
    {
        internal int GetTempFarenheit(City city, State state)
        {
            throw new NotImplementedException();
        }
    }

    public class GeoLookupService
    {
        internal City GetCityForZipCode(string zipCode)
        {
            throw new NotImplementedException();
        }

        internal State GetStateForZipCode(string zipCode)
        {
            throw new NotImplementedException();
        }
    }

    public class ConverterService
    {
        internal int ConvertFarenheitToCelcius(int tempF)
        {
            throw new NotImplementedException();
        }
    }

    public class WeatherFacadeResults
    {
        public int Farenheit { get; set; }
        public int Celcius { get; set; }
        public City City { get; set; } 
        public State state { get; set; }
    }

    public class State
    {
    }

    public class City
    {
    }
}
