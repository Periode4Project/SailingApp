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
    public partial class Editactivity : ContentPage
    {
        public Editactivity()
        {
            InitializeComponent();
        }
        private async void AddActivity_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            //brengt je terug naar adminmoderate pagina zodat je verder kan gaan met editen)
        }
    }
}