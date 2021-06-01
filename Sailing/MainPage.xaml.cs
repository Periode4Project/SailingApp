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
            activityItems = new List<ActivityItem>(ActivityItems.Get());
            collectionViewListHorizontal.ItemsSource = activityItems;
        }


        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedActivity.activityItem = (ActivityItem)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new ActivityPage());
        }

        private async void FilterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterResults());
        }
    }
}
