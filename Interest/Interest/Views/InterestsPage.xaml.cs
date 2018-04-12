using System;
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

        private async void EditInterests(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewEditPage());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selection = e.SelectedItem as Models.Interest;
                
               // await DisplayAlert("Alert", "You have selected: " + selection.Title, "Ok");
               await Navigation.PushAsync(new GetNewsPage(selection.Title));
            }
        }

        private async  void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}