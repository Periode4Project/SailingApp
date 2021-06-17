using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace Sailing
{
    public partial class MainPage : ContentPage
    {
        bool isGettingLocation;
        LocationClass LocationClass = new LocationClass();

        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            isGettingLocation = true;

            while (isGettingLocation)
            {
                var result = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));

                resultLocation.Text += $"lat: {result.Latitude}, lng: {result.Longitude}{Environment.NewLine}";

                await Task.Delay(1000);
            }
        }

        void Button1_Clicked(System.Object sender, System.EventArgs e)
        {
            isGettingLocation = false;
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {

            cityResult.Text = await LocationClass.GetLocation();
            double Distance = await LocationClass.GetDistance();
            distanceResult.Text = Distance.ToString(); 

            


            //Location current = new Location(result.Latitude, result.Longitude);
            //Location sanFrancisco = new Location(37.783333, -122.416667);
            //double Kilometer = Location.CalculateDistance(current, sanFrancisco, DistanceUnits.Kilometers);

            //distanceResult.Text = Convert.ToString(Kilometer);
        }
    }
}
