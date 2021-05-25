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
            ActivityLocation.Text = CurrentItem.ActivityLocation;
            ActivityType.Text = CurrentItem.ActivityType;
            ActivityFee.Text = CurrentItem.EntranceFee.ToString();
            ActivityDescription.Text = CurrentItem.ActivityDesc;
        }
    }
}