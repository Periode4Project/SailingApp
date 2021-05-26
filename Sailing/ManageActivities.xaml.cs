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
    public partial class ManageActivities : ContentPage
    {
        public ManageActivities()
        {
            InitializeComponent();
        }
         private async void AddActivitiesButton_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}