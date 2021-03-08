using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WeatherApp;
using WeatherAppYar.Models;
using Xamarin.Forms;

namespace WeatherAppYar.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        
        public string Id { get; set; }
        public string Broadcast { get; }




        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
