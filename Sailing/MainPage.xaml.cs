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
            //activityItems = new List<ActivityItem>(ActivityItems.Get());
            activityItems =  ApiRepositories.Activities.GetAllActivities();
            collectionViewListHorizontal.ItemsSource = activityItems;
        }


        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedActivity.activityItem = (ActivityItem)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new ActivityPage());
        }
    }
}
