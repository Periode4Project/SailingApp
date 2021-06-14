﻿using System;
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
            await Navigation.PushAsync(new ActivityPage());
        }

        private async void FilterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterResults());
        }
    }
}