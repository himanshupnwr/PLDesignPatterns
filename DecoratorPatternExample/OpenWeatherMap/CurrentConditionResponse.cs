using System.Text.Json;
using System.Text.Json.Serialization;

namespace DecoratorPatternExample.OpenWeatherMap
{
    public class CurrentConditionsResponse
    {
        /// <summary>
        /// A description of any error that occured
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("id")]
        public int CityId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("coord")]
        public Coordinates Coordintates { get; set; }

        [JsonPropertyName("dt")]
        public int ObservationTime { get; set; }

        [JsonPropertyName("weather")]
        public ObservedConditions[] ObservedConditions { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("rain")]
        public RainData Rain { get; set; }

        [JsonPropertyName("main")]
        public ObservationData ObservationData { get; set; }

        [JsonPropertyName("wind")]
        public WindData WindData { get; set; }

        [JsonPropertyName("sys")]
        public LocationDetails LocationDetails { get; set; }

        [JsonPropertyName("timezone")]
        public int TimezoneOffset { get; set; }
    }


    public class Coordinates
    {
        [JsonPropertyName("lon")]
        public float Longitude { get; set; }

        [JsonPropertyName("lat")]
        public float Latitude { get; set; }
    }

    public class ObservationData
    {
        [JsonPropertyName("temp")]
        public float Temperature { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("temp_min")]
        public float MinTemperature { get; set; }

        [JsonPropertyName("temp_max")]
        public float MaxTemperature { get; set; }
    }

    public class WindData
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Degrees { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int CloudCover { get; set; }
    }

    public class RainData
    {
        [JsonPropertyName("1h")]
        public double RainfallOneHour { get; set; }
    }

    public class LocationDetails
    {
        [JsonPropertyName("country")]
        public string country { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }

    public class ObservedConditions
    {
        [JsonPropertyName("id")]
        public int DescriptionId { get; set; }

        [JsonPropertyName("main")]
        public string Conditions { get; set; }

        [JsonPropertyName("description")]
        public string ConditionsDetail { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
