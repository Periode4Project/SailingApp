using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sailing
{

    public partial class MainPage : ContentPage
    {
        public List<ActivityItem> activityItems { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();ActivityItems.Get();
            collectionViewListHorizontal.ItemsSource = activityItems;
        }

        private async void ActivityClicked_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActivityPage());
        }
    }
}
