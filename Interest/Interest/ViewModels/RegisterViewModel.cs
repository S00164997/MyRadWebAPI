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
        ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                string Message;
                return new Command(async() =>
                {
                    var isSuccess = await _apiServices.RegisterAsync(Email, Password, ConfirmPassword);
                    if (isSuccess)
                          Message = "Registered Successfully";
                    else
                    {
                        Message = "Retry later";
                    }
                });
            }
        }
    }
}
