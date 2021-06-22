using Sailing.UserPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sailing
{

    public partial class MainPage : ContentPage
    {
        public List<ActivityItem> activityItems { get; set; }

        public MainPage()
        {
            if (Config.FirstStartup)
            {
                //handle first startup
            }
            bool isDone = false;
            InitializeComponent();
            //Create background thread to handle webrequest, remedies stuck on splash screen
            new Thread(async () =>
            {
                activityItems = new List<ActivityItem>(await ActivityItems.GetAsync());
                isDone = true;
            }).Start();
            //while it's not done, wait 1 second
            while (!isDone)
                Thread.Sleep(1);
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
