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
    public partial class OnBoarding1 : ContentPage
    {
        public OnBoarding1()
        {
            InitializeComponent();
        }
        private async void SkipButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());

        }
        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());

        }
    }
}