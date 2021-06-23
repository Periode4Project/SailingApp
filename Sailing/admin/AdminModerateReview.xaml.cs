using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sailing;
using Sailing.UserPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sailing.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminModerateReview : ContentPage
    {
        public List<Review> ListReviews { get; set; }
        public AdminModerateReview()
        {
            bool isDone = false;
            InitializeComponent();
            //Create background thread to handle webrequest, remedies stuck on splash screen
            new Thread(async () =>
            {
                ListReviews = await Reviews.GetAsync();
                isDone = true;
            }).Start();
            //while it's not done, wait 1 second
            while (!isDone)
                Thread.Sleep(1);
            collectionViewListHorizontal.ItemsSource = ListReviews;
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (collectionViewListHorizontal.SelectedItem == null)
                return;
            bool answer = await DisplayAlert("Warning:", "Do you want to delete this review?", "Yes", "No");
            if (answer)
            {
                
                Review review = (Review)e.CurrentSelection.FirstOrDefault();
                await admin.ReviewDeletion.IsDeleteReviewSuccessful(review.ReviewID);
                await Navigation.PushAsync(new AdminModerateReview());
            }
            else
            {
                await DisplayAlert("Cancelled", "Review has not been deleted.", "OK");
                collectionViewListHorizontal.SelectedItem = null;
            }
        }
    }
}
// pagina wordt herladen wanneer review verwijderd wordt
// Reviews kunnen beter alleen verwijderd te worden