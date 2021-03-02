using System;
using System.Collections.Generic;
using WeatherApp;
using WeatherAppYar.Services;
using WeatherAppYar.ViewModels;
using WeatherAppYar.Views;
using Xamarin.Forms;

namespace WeatherAppYar
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        RestService _restService;
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            _restService = new RestService();
            GetWeather();
        }
        async void GetWeather()
        {
            WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
            weatherData.Current.Weather[0].Icon = "w" + weatherData.Current.Weather[0].Icon + ".png";
            BindingContext = weatherData;
        }
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

    }
}
