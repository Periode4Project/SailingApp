﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sailing
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ActivityClicked_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActivityPage());
        }
    }
}
