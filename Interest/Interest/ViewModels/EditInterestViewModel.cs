using Interest.Services;
using Interest.Models;
using Interest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Interest.ViewModels
{
   public class EditInterestViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public Models.Interest Interest { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServices.PutIdeaAsync(Interest, Settings.AccessToken);
                });
            }
        }
        //public ICommand DeleteCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            await _apiServices.DeleteIdeaAsync(Interest.Id, Settings.AccessToken);
        //        });
        //    }
        //}
    }
}
