using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp;
using WeatherAppYar.Models;

namespace WeatherAppYar.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        RestService _restService1;
        List<Item> items;
        

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += "?lat=57.629971";
            requestUri += "&lon=39.87279";
            requestUri += "&units=metric";
            requestUri += "&exclude=minutely,hourly";
            requestUri += $"&APPID={Constants.OpenWeatherMapApiKey}";
            return requestUri;
        }
        public MockDataStore()
        {
            _restService1 = new RestService();
            GetWeather();
            
        }
        async void GetWeather()
        {
            WeatherData weatherData = await _restService1.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
            weatherData.Current.Weather[0].Icon = "w" + weatherData.Current.Weather[0].Icon + ".png";
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(),
                           TemperatureDifference = $"between {weatherData.Daily[0].Temp.Max}° and {weatherData.Daily[0].Temp.Min}°",
                           WindSpeed = $"{weatherData.Daily[0].WindSpeed} m/s",
                           Humidity = $"{weatherData.Daily[0].Humidity} %",
                           Pressure = $"{weatherData.Daily[0].Pressure} hpa",
                           Precipitation = $"{weatherData.Daily[0].Weather[0].Visibility}",
                           PrecipitationIcon = $"n{weatherData.Daily[0].Weather[0].Icon}.png",
                           Date = weatherData.Daily[0].Dt},
                new Item { Id = Guid.NewGuid().ToString(),
                           TemperatureDifference = $"between {weatherData.Daily[1].Temp.Max}° and {weatherData.Daily[1].Temp.Min}°",
                           WindSpeed = $"{weatherData.Daily[1].WindSpeed} m/s",
                           Humidity = $"{weatherData.Daily[1].Humidity} %",
                           Pressure = $"{weatherData.Daily[1].Pressure} hpa",
                           Precipitation = $"{weatherData.Daily[1].Weather[0].Visibility}",
                           PrecipitationIcon = $"n{weatherData.Daily[1].Weather[0].Icon}.png",
                           Date = weatherData.Daily[1].Dt},
                new Item { Id = Guid.NewGuid().ToString(),
                           TemperatureDifference = $"between {weatherData.Daily[2].Temp.Max}° and {weatherData.Daily[2].Temp.Min}°",
                           WindSpeed = $"{weatherData.Daily[2].WindSpeed} m/s",
                           Humidity = $"{weatherData.Daily[2].Humidity} %",
                           Pressure = $"{weatherData.Daily[2].Pressure} hpa",
                           Precipitation = $"{weatherData.Daily[2].Weather[0].Visibility}",
                           PrecipitationIcon = $"n{weatherData.Daily[2].Weather[0].Icon}.png",
                           Date = weatherData.Daily[2].Dt},
                new Item { Id = Guid.NewGuid().ToString(),
                           TemperatureDifference = $"between {weatherData.Daily[3].Temp.Max}° and {weatherData.Daily[3].Temp.Min}°",
                           WindSpeed = $"{weatherData.Daily[3].WindSpeed} m/s",
                           Humidity = $"{weatherData.Daily[3].Humidity} %",
                           Pressure = $"{weatherData.Daily[3].Pressure} hpa",
                           Precipitation = $"{weatherData.Daily[3].Weather[0].Visibility}",
                           PrecipitationIcon = $"n{weatherData.Daily[3].Weather[0].Icon}.png",
                           Date = weatherData.Daily[3].Dt},
                new Item { Id = Guid.NewGuid().ToString(),
                           TemperatureDifference = $"between {weatherData.Daily[4].Temp.Max}° and {weatherData.Daily[4].Temp.Min}°",
                           WindSpeed = $"{weatherData.Daily[4].WindSpeed} m/s",
                           Humidity = $"{weatherData.Daily[4].Humidity} %",
                           Pressure = $"{weatherData.Daily[4].Pressure} hpa",
                           Precipitation = $"{weatherData.Daily[4].Weather[0].Visibility}",
                           PrecipitationIcon = $"n{weatherData.Daily[4].Weather[0].Icon}.png",
                           Date = weatherData.Daily[4].Dt},
                new Item { Id = Guid.NewGuid().ToString(),
                           TemperatureDifference = $"between {weatherData.Daily[5].Temp.Max}° and {weatherData.Daily[5].Temp.Min}°",
                           WindSpeed = $"{weatherData.Daily[5].WindSpeed} m/s",
                           Humidity = $"{weatherData.Daily[5].Humidity} %",
                           Pressure = $"{weatherData.Daily[5].Pressure} hpa",
                           Precipitation = $"{weatherData.Daily[5].Weather[0].Visibility}",
                           PrecipitationIcon = $"n{weatherData.Daily[5].Weather[0].Icon}.png",
                           Date = weatherData.Daily[5].Dt},
                new Item { Id = Guid.NewGuid().ToString(),
                           TemperatureDifference = $"between {weatherData.Daily[6].Temp.Max}° and {weatherData.Daily[6].Temp.Min}°",
                           WindSpeed = $"{weatherData.Daily[6].WindSpeed} m/s",
                           Humidity = $"{weatherData.Daily[6].Humidity} %",
                           Pressure = $"{weatherData.Daily[6].Pressure} hpa",
                           Precipitation = $"{weatherData.Daily[6].Weather[0].Visibility}",
                           PrecipitationIcon = $"n{weatherData.Daily[6].Weather[0].Icon}.png",
                           Date = weatherData.Daily[6].Dt},


            };

        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}