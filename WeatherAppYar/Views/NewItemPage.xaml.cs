using System;
using System.Collections.Generic;
using System.ComponentModel;
using WeatherAppYar.Models;
using WeatherAppYar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherAppYar.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}