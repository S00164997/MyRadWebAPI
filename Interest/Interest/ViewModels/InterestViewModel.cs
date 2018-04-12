using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Interest.Services;
using Xamarin.Forms;
using Interest.Helpers;
using Interest.Models;

namespace Interest.ViewModels
{
    public class InterestViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices _apiServices = new ApiServices();
        private List<Interest.Models.Interest> _interests;

      //  public string AccessToken { get; set; } Dont need any more due to helpers/settings

        public List<Interest.Models.Interest> Interests 

        {
            get { return _interests; }
            set
            {
                _interests = value;
                OnPropertyChanged();
}
        }
        public ICommand GetInterestsCommand
        {
            get
            {
                return new Command(async () =>
                {
                       var accessToken = Settings.AccessToken;
                    Interests = await _apiServices.GetInterestsAsync(accessToken);
                });
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Settings.AccessToken = string.Empty;
                    Debug.WriteLine(Settings.Username);
                    Settings.Username = string.Empty;
                    Debug.WriteLine(Settings.Password);
                    Settings.Password = string.Empty;

                    // navigate to LoginPage
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
