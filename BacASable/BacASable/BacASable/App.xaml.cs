using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BacASable.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BacASable
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjI5NDFAMzEzNjJlMzIyZTMwQ3kxUXhwZVU3cmIyUGdoanY0V295QnRhaXQzNFpYaTU3N0RoY2RBWnl0dz0=");

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
