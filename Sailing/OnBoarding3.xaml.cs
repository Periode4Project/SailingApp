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
    public partial class OnBoarding3 : ContentPage
    {
        public OnBoarding3()
        {
            InitializeComponent();
        }
        private async void PrevButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OnBoarding2());

        }

        private async void SkipButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());

        }
        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();

        }
    }
}