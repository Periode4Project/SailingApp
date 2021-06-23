using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            bool isDone = false;
            InitializeComponent();
            //Create background thread to handle webrequest, remedies stuck on splash screen
            new Thread(async () =>
            {
                activityItems = new List<ActivityItem>(await ActivityItems.GetAsync());
                isDone = true;
            }).Start();
            //while it's not done, wait 1 second
            while (!isDone)
                Thread.Sleep(1);
            collectionViewListHorizontal.ItemsSource = activityItems;
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivityItem activity = (ActivityItem)e.CurrentSelection.FirstOrDefault();
            await admin.ActivityDeletion.IsDeleteActivitySuccessful(activity.ActivityId);
            await Navigation.PushAsync(new AdminModerateActivity());
        }
    }
}