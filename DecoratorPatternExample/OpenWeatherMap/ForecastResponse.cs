using System.Text.Json.Serialization;

namespace DecoratorPatternExample.OpenWeatherMap
{
    public class ForecastResponse
    {
        public string cod { get; set; }
        public float message { get; set; }

        [JsonPropertyName("list")]
        public OpenWeatherForecastData[] ForecastPoints { get; set; }

        [JsonPropertyName("city")]
        public OpenWeatherForecastLocation Location { get; set; }
    }


    public class OpenWeatherForecastData
    {
        [JsonPropertyName("dt")]
        public int Date { get; set; }

        [JsonPropertyName("main")]
        public OpenWeatherForecastWeatherData WeatherData { get; set; }

        [JsonPropertyName("weather")]
        public OpenWeatherForecastConditions[] Conditions { get; set; }

        [JsonPropertyName("clouds")]
        public OpenWeatherForecastClouds Clouds { get; set; }

        [JsonPropertyName("wind")]
        public OpenWeatherForecastWind Wind { get; set; }
        public string dt_txt { get; set; }

        [JsonPropertyName("rain")]
        public OpenWeatherForecastRain Rain { get; set; }

        [JsonPropertyName("snow")]
        public OpenWeatherForecastSnow Snow { get; set; }
    }


    public class OpenWeatherForecastLocation
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("coord")]
        public OpenWeatherForecastCoordinates Coordinates { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("timezone")]
        public int TimezoneOffset { get; set; }
    }

    public class OpenWeatherForecastCoordinates
    {
        [JsonPropertyName("lat")]
        public float Latitude { get; set; }

        [JsonPropertyName("lon")]
        public float Longitude { get; set; }
    }



    public class OpenWeatherForecastWeatherData
    {
        [JsonPropertyName("temp")]
        public float Temperature { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }

        [JsonPropertyName("Pressure")]
        public float pressure { get; set; }
        public float sea_level { get; set; }
        public float grnd_level { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class OpenWeatherForecastClouds
    {
        [JsonPropertyName("all")]
        public int CloudCover { get; set; }
    }

    public class OpenWeatherForecastWind
    {
        [JsonPropertyName("speed")]
        public float WindSpeed { get; set; }

        [JsonPropertyName("deg")]
        public int WindDirectionDegrees { get; set; }
    }


    public class OpenWeatherForecastRain
    {
        [JsonPropertyName("3h")]
        public float RainfallThreeHours { get; set; }
    }

    public class OpenWeatherForecastSnow
    {
        [JsonPropertyName("3h")]
        public float SnowfallThreeHours { get; set; }
    }

    public class OpenWeatherForecastConditions
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
