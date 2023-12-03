using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace xa
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            string selectedPage = pagePicker.SelectedItem as string;

            if (selectedPage == "Page2")
            {
                await Navigation.PushAsync(new Page2());
            }
            else if (selectedPage == "Page3")
            {
                await Navigation.PushAsync(new Page3());
            }
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the picker selected index changed event if needed
        }
    }
}