using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Sailing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        LocationClass locationClass = new LocationClass();
      
        

        public Settings()
        {
            InitializeComponent();

            var timer = new System.Threading.Timer((e) =>
            {
                SetLocation();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            
        }

        private async void SaveSettings_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Confirmation","Are you sure you wish to continue?","Yes","No");
            switch (result)
            {
                case true:
                    await DisplayAlert("Success","Settings succesfuly saved!","Ok");
                    break;
            }
        }

        private void GetStartedButton_Clicked(object sender, EventArgs e)
        {
            
        }

        

        private async void SetLocation()
        {
            //string LocationText = await locationClass.GetLocation();

            //switch (LocationText)
            //{
            //    case "Please enable GPS":
            //        await DisplayAlert("Alert", "Please turn on GPS", "OK");
            //        //voor nu wacht hij 10 seconden en probeert het weer
            //        await Task.Delay(10 * 1000);
            //        SetLocation();
            //        break;

            //    default:
            //        GPSLocation.Text = LocationText;
            //        break;
            //}
            //while (true)
            //{
                

            //    await Task.Delay(10000);
            //}

            //haalt de huidige locatie in coordinaten op uit de Coordinates class en geeft die mee aan de GetlocationName van de locationclass 
            GPSLocation.Text = await locationClass.GetLocationName(Coordinates.currentLocation);
            

        }
    }
}