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
    public partial class AdminModerateReview : ContentPage
    {
        public AdminModerateReview()
        {
            InitializeComponent();
            ActivityItem CurrentItem = SelectedActivity.activityItem;
        }
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminModerateReview());
        }
    }
}
// pagina wordt herladen wanneer review verwijderd wordt
// Reviews kunnen beter alleen verwijderd te worden