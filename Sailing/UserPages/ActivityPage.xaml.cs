using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sailing;

namespace Sailing.UserPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        public List<Review> ReviewsList { get; set; }
        /// <summary>
        /// zet de activity op met de informatie die er bji hoort
        /// </summary>
        public ActivityPage()
        {
            bool isDone = false;
            InitializeComponent();
            ActivityItem CurrentItem = SelectedActivity.activityItem;
            ActivityImg.Source = CurrentItem.ActivityImage;
            ActivityName.Text = CurrentItem.ActivityName;
            ActivityLocation.Text = CurrentItem.ActivityPlace.Address;
            ActivityType.Text = CurrentItem.ActivityType;
            ActivityFee.Text = CurrentItem.EntranceFee.ToString();
            ActivityDescription.Text = CurrentItem.ActivityDesc;
            //Create background thread to handle webrequest, remedies stuck on splash screen
            //haalt de reviews op
            new Thread(async () =>
            {
                ReviewsList = new List<Review>(await Reviews.GetAsync(CurrentItem.ActivityId));
                isDone = true;
            }).Start();
            //while it's not done, wait 1 second
            while (!isDone)
                Thread.Sleep(1);
            double totalrating = 0;
            foreach (Review rating in ReviewsList)
            {
                totalrating += rating.Rating;
            }
            if (ReviewsList.Count() > 0)
                AverageRating.Text = Math.Round(totalrating / ReviewsList.Count(), 2).ToString();
            else
                AverageRating.Text = "10";
            ReviewAmount.Text = ReviewsList.Count().ToString();
            collectionViewListHorizontal.ItemsSource = ReviewsList;
            
        }
        /// <summary>
        /// knop voor review toevoegen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddReview_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewReview());
        }
    }
}