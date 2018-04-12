using Interest.Helpers;
using Interest.Services;
using Interest.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Interest.ViewModels
{
   public class LoginViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {//after this enters a loop
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);
                    //MessagingCenter.Send("Notification", accesstoken, "No");
                     Settings.AccessToken = accesstoken;

                    await Application.Current.MainPage.DisplayAlert("Alert", "You have successfully logged in", "OK");
                    
                });
            }
        }

        

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }

    }
}
