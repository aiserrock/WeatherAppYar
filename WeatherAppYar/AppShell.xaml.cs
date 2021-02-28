using System;
using System.Collections.Generic;
using WeatherAppYar.ViewModels;
using WeatherAppYar.Views;
using Xamarin.Forms;

namespace WeatherAppYar
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
