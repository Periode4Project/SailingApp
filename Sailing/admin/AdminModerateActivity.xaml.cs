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
    public partial class AdminModerateActivity : ContentPage
    {
        public List<ActivityItem> activityItems { get; set; }
        public AdminInt boolInt { get; set; }

        public AdminModerateActivity()
        {
            InitializeComponent();
            activityItems = new List<ActivityItem>(ActivityItems.Get());
            collectionViewListHorizontal.ItemsSource = activityItems;
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedActivity.activityItem = (ActivityItem)e.CurrentSelection.FirstOrDefault();
            await Navigation.PushAsync(new UserPages.ActivityPage());
        }

        private async void FilterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterResults());
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Editactivity());
            // brengt je naar de editpagina
        }
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminModerateActivity());
            // dit is alleen tijdelijk omdat ik alleen front-end maakte, verwijder naar eigen inzicht
        }
    }
}