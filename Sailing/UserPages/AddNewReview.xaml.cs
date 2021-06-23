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
    public partial class AddNewReview : ContentPage
    {
        public AddNewReview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If the necessary field(s) are/is empty(null), Display error. Otherwise, Send to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ReviewSubmit_Clicked(object sender, EventArgs e)
        {
            if ((RevTitle.Text != null) && (RevRating.Text != null) && (RevExp.Text != null))
            {
                if (await SubmitReview.IsSuccessful(RevTitle.Text, RevExp.Text, Convert.ToDouble(RevRating.Text), SelectedActivity.activityItem.ActivityId))
                {
                    await DisplayAlert("Success", "Review Succesfully Submitted!", "OK");
                }
                else
                    await DisplayAlert("Error", "Review was not Submitted!", "OK");

            }
            else
            {
                await DisplayAlert("Error", "You forgot a field!", "OK");
            }
        }
    }
}