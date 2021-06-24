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
    public partial class MyAccount : ContentPage
    {
        public MyAccount()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            Config.Read();
            if (await configuration.Auth.CheckIsValidLogin(writecfg: false))
            {
                Config.User.Email = null;
                Config.User.Password = null;
                Config.Write();
                await Navigation.PushAsync(new Login());
            }
            else
                await Navigation.PushAsync(new Login());
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Config.Read();
            if (await configuration.Auth.CheckIsValidLogin(writecfg: false))
            {
                await DisplayAlert("You can't do this right now.", "Please log out before registering an account", "OK");
            }
            else
                await Navigation.PushAsync(new Register());

        }
        private async void Admin_Clicked(object sender, EventArgs e)
        {
            Config.Read();
            if (!await configuration.Auth.CheckIsUserAdmin())
            {
                await DisplayAlert("You can't do this right now.", $"Please log in as admin, {Config.User.Email}", "OK");
            }
            else
                await Navigation.PushAsync(new Adminpanel());

        }
    }
}