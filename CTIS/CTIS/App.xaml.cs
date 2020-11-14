using CTIS.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTIS
{
    public partial class App : Application
    {
        public LoginPage LoginPage { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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
