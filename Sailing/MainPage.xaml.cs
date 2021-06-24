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
using System.Windows.Input;

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
            
            //eerste startup moet tutorial worden laten zien
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
                //haalt de activiteiten op van de api
                activityItems = new List<ActivityItem>(await ActivityItems.GetAsync());
                isDone = true;
            }).Start();
            //while it's not done, wait 1 second
            while (!isDone)
                Thread.Sleep(1);

            //bepaald welke activiteiten moeten worden laten zien
            SetActivities();

            //update de huidige locatie via gps
            UpdateLocation();
        }

        /// <summary>
        /// maakt een lijst aan van activiteiten die worden laten zie gebaseerd op de afstand tot de activiteit
        /// </summary>
        public async void SetActivities()
        {
            //maak lijst aan 
            List<ActivityItem> shownActivities = new List<ActivityItem>();
            //haal de huidige locatie op
            currentLocation = await locationClass.GetCoordinates();
            Coordinates.currentLocation = currentLocation;

            //ga alle activiteiten langs die zijn opgehaald in de mainpage en in de activityItems list zitten
            foreach (var item in activityItems)
            {
                //maak een Location aan waar de locatie van de lijst in wordt gezet 
                Location other = new Location(item.ActivityPlace.Location.lat, item.ActivityPlace.Location.lng);
                //bereken de afstand tot de locatie
                double distance = locationClass.GetDistance(other);

                //als de afstand kleiner dan 10km is dan wordt hij toegevoegd aan de lijst 
                if (distance < 10)
                {
                    shownActivities.Add(item);
                }
            }

            //de collectionViewlist wordt geupdate met de locaties die we willen laten zien
            collectionViewListHorizontal.ItemsSource = shownActivities;
        }

        /// <summary>
        /// update de locatie elke 10 seconden en update de Coordinates class
        /// </summary>
        public async void UpdateLocation()
        {
            
            while (GetLocation)
            {
                currentLocation = await locationClass.GetCoordinates();
                Coordinates.currentLocation = currentLocation;
                await Task.Delay(10000);
            }
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedActivity.activityItem = (ActivityItem)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new ActivityPage());            
        }
        /// <summary>
        /// laat het filter menu zien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FilterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterResults());
        }

        /// <summary>
        /// handelt het refreshen van locaties, als de scrollview omlaag wordt gescrolled worden de activities die moeten worden laten zien gerefreshed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            bool isDone = false;

            new Thread(async () =>
            {
                activityItems = new List<ActivityItem>(await ActivityItems.GetAsync());
                isDone = true;
            }).Start();
            //while it's not done, wait 1 second
            while (!isDone)
                Thread.Sleep(1);
            SetActivities();
            //content is gerefreshed dus refresh icoontje kan weg
            Refresh.IsRefreshing = false;
        }
    }
}
