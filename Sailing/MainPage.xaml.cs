using Sailing.UserPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Sailing
{

    public partial class MainPage : ContentPage
    {
        public List<ActivityItem> activityItems { get; set; }

        LocationClass locationClass = new LocationClass();

        public Location currentLocation;

        public bool GetLocation = true;

        public MainPage()
        {
            

            if (Config.FirstStartup)
            {
                //handle first startup
                Navigation.PushAsync(new OnBoarding1());
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

            SetActivities();
            UpdateLocation();
        }


        public async void SetActivities()
        {
            List<ActivityItem> shownActivities = new List<ActivityItem>();
            
            currentLocation = await locationClass.GetCoordinates();
            Coordinates.currentLocation = currentLocation;

            foreach (var item in activityItems)
            {
                Location other = new Location(item.ActivityPlace.Location.lat, item.ActivityPlace.Location.lng);
                double distance = locationClass.GetDistance(other);

                //afstand waar de locatie binnen moet liggen
                if (distance < 10)
                {
                    shownActivities.Add(item);
                }
                
                
            }

            collectionViewListHorizontal.ItemsSource = shownActivities;

            
        }

        public async void UpdateLocation()
        {
            
            while (GetLocation)
            {
                currentLocation = await locationClass.GetCoordinates();
                Coordinates.currentLocation = currentLocation;
                await Task.Delay(10000);
                //zorgt ervoor dat de activities worden geupdate, kan misschien een langere cooldown hebben
                SetActivities();
            }
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
