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
    public partial class Adminpanel : ContentPage
    {
        public Adminpanel()
        {
            InitializeComponent();
        }
        private async void Activity_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminModerateActivity());
        }

        private async void AddActivity_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Addactivity());
        }

        private async void Review_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminModerateReview());

        }
        private async void Mail_Clicked(object sender, EventArgs e)
        {
            string url = "https://mail.google.com/";
            await Launcher.OpenAsync(new Uri(url));
        }
    }
}