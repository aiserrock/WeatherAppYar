using System;

namespace WeatherAppYar.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string TemperatureDifference { get; set; }
        public string WindSpeed { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public string Precipitation { get; set; }
        public string PrecipitationIcon { get; set; }
        public long Date { get; set; }
    }
}