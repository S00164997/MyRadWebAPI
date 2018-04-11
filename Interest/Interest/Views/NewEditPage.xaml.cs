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
    public partial class NewEditPage : ContentPage
    {
        public NewEditPage()
        {
            InitializeComponent();
        }
        private async void IdeasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var interest = e.Item as Models.Interest;
            // Item.Interest as 
            await Navigation.PushAsync(new EditInterestPage(interest));
        }
    }
}