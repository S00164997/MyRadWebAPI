﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interest.Views;
using Xamarin.Forms;
using Interest.Helpers;
using Interest.ViewModels;


namespace Interest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetMainPage();
            // MainPage = new NavigationPage(new RegisterPage()); 
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                //if (Settings.AccessTokenExpirationDate < DateTime.UtcNow.AddHours(1))
                //{
                //    var loginViewModel = new LoginViewModel();
                //    loginViewModel.LoginCommand.Execute(null);
                //}
                MainPage = new NavigationPage(new InterestsPage());
            }
            else if (!string.IsNullOrEmpty(Settings.Username)
                  && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
