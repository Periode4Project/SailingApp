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
    public partial class SuggestActivity : ContentPage
    {
        public SuggestActivity()
        {
            InitializeComponent();
        }

        private async void Suggest_Clicked(object sender, EventArgs e)
        {
            if (LocationInput.Text != null || NameInput != null)
            {
                await DisplayAlert("Submitted!","Suggestion is ready for Review","OK");
                //Submit to Admin
            }
            else
            {
                await DisplayAlert("Error","You forgot a field!","OK");
            }
        }
    }
}