using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sailing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        public ActivityPage()
        {
            InitializeComponent();
            ActivityItem CurrentItem = SelectedActivity.activityItem;
            ActivityImg.Source = CurrentItem.ActivityImage;
            ActivityName.Text = CurrentItem.ActivityName;
            ActivityLocation.Text = CurrentItem.ActivityPlace.Address;
            ActivityType.Text = CurrentItem.ActivityType;
            ActivityFee.Text = CurrentItem.EntranceFee.ToString();
            ActivityDescription.Text = CurrentItem.ActivityDesc;
        }

        private async void AddReview_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewReview());
        }
    }
}