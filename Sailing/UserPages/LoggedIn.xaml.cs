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
    public partial class LoggedIn : ContentPage
    {
        public LoggedIn()
        {
            InitializeComponent();
        }

        private async void LoggingOut_Clicked(object sender, EventArgs e)
        {
            //TODO Current session Remove Session
            await Navigation.PushAsync(new Login());
        }

        private async void Suggestion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SuggestActivity());
        }
    }
}