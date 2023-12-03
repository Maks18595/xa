using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xa
{
    public partial class MainPage : ContentPage

    {
        private static string bomb = new Random().Next(1, 4).ToString();
        static int scores = 0;
     
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void ButtonClicked(object sender, EventArgs e)
        {
           Button button = sender as Button;
            if (button.Text == bomb)
            {
                scores = 0;
                await DisplayAlert("Bomb Exploded", "Game over", "Retry");
           bomb = new Random().Next(1, 4).ToString();
            }
            else
            {
                scores += 10;
                await DisplayAlert("Bomb Defused!", "Scores: " + scores, "Continue");
                bomb = new Random().Next(1, 4).ToString();
            }
        }
       
        private void OnAddNumbersClicked(object sender, EventArgs e)
        {

            if (double.TryParse(entryNumber1.Text, out double number1) && double.TryParse(entryNumber2.Text, out double number2))
            {

                double result = number1 + number2;


                resultLabel.Text = $"Result: {result}";
                entryNumber1.Text = "";
                entryNumber2.Text = "";
            }
            else
            {
                resultLabel.Text = "Please enter valid numbers.";
            }
        }
        private async void GoToNewPageClicked(object sender, EventArgs e)
        {
            // Створіть новий екземпляр сторінки
            Page1 newPage = new Page1();
           

            // Приховати панель навігації
            NavigationPage.SetHasNavigationBar(newPage, true);

            // Використовуйте PushAsync для переходу на нову сторінку
            await Navigation.PushAsync(newPage);
        }
    }
}
