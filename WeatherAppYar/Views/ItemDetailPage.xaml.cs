using System.ComponentModel;
using WeatherAppYar.ViewModels;
using Xamarin.Forms;

namespace WeatherAppYar.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}