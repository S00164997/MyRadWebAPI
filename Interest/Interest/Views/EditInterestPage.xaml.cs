using Interest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditInterestPage : ContentPage
    {
        public EditInterestPage(Models.Interest interest)
        {
            
            InitializeComponent();
            var editInterestViewModel = new EditInterestViewModel();
            editInterestViewModel.Interest = interest;

            BindingContext = editInterestViewModel;

            DisplayAlert("Alert", "Done", "Ok");

            //var editInterestViewModel = BindingContext as EditInterestViewModel;

            //editInterestViewModel.Interest = interest;

        }
    }
}