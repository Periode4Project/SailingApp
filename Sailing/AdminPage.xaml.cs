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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        private async void ActivitiesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManageActivities());

        }
        private async void LogOutButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());

        }
    }
}