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
        public Login()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            //Login Validation and Continue 
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());

        }

        private void ForgotPW_Clicked(object sender, EventArgs e)
        {
            //Make New Password
        }

        private async void Debug_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoggedIn());
        }
    }
}