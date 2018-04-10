﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interest.Services;
using System.Windows.Input;
using Xamarin.Forms;
using Interest.Helpers;

namespace Interest.ViewModels
{
    class AddNewInterestViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public string Title { get; set; }
        string random;

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var interest = new Models.Interest
                    {
                        Title = "Blah",
                        UserId = "ewfvifijvoei",
                        Id = 3
                    };
                    await _apiServices.PostIdeaAsync(interest, Settings.AccessToken);
                });
            }
        }
    }
}
