using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SetLocation();
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
            GPSLocation.Text = await locationClass.GetLocation();
        }
    }
}