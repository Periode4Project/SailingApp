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
    public partial class Login : ContentPage
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public Login()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (Config.User == null)
                Config.User = new User { };
            Config.User.Email = EmailField.Text;
            Config.User.Password = PasswordField.Text;
            bool isValid = await configuration.Auth.CheckIsValidLogin(writecfg: true);
            if (isValid)
                await Navigation.PushAsync(new MainPage());
            else
                await DisplayAlert("Invalid Credentials", "We were unable to log you in. Please try again.", "OK");
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());

        }

        private async void Debug_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoggedIn());
        }
    }
}