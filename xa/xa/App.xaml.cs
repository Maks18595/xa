using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xa
{
    public partial class App : Application
    {
        public Color BarBackgroundColor { get; }
        public Color BarTextColor { get; }
        public Color BarBackgroundColor1 { get; }
        public Color BarTextColor2 { get; }
        public NavigationPage Page1 { get; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            {
                BarBackgroundColor = Color.Transparent;
                BarTextColor = Color.White;
            }
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
