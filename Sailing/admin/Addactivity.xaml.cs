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
    public partial class Addactivity : ContentPage
    {
        public Addactivity()
        {
            InitializeComponent();
        }
        private async void AddActivity_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Adminpanel());
        }
    }
}