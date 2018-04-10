﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Interest.Models;

namespace Interest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InterestsPage : ContentPage
    {
        public InterestsPage()
        {
            InitializeComponent();
        }

       

        private async void NavigateToAddNewInterestAsync_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewInterestPage());
        }
    }
}