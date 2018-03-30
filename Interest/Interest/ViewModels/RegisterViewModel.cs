using Interest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;



namespace Interest.ViewModels
{
    public class RegisterViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                
                return new Command(async() =>
                {
                    var isSuccess = await _apiServices.RegisterAsync(Email, Password, ConfirmPassword);

                    System.Diagnostics.Debug.WriteLine("neh");
                    if (isSuccess){
                        System.Diagnostics.Debug.WriteLine("Here");
                        Message = "Registered Successfully";
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Boom");
                        Message = "Retry later";
                    }
                });
            }
        }
    }
}
