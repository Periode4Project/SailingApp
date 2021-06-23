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
    public partial class FilterResults : ContentPage
    {
        public FilterResults()
        {
            InitializeComponent();
        }


        private void MaxVal_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            DisplayMaxVal.Text = MaxVal.Value.ToString();
            if (DisplayMaxVal.Text == "50")
            {
                Plus.IsVisible = true;
            }
            else
            {
                Plus.IsVisible = false;
            }
        }

        private async void SaveFilters_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
            //dit is voor zowel vanuit de mainpage komen als uit de adminmoderateactivity komen dus hier moeten nog wat extra lijnen bijkomen zodat je naar goede pagina terugkomt met een of ander if statement.
        }
    }
}