using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Usuario.Models;
using Xamarin.Forms;

namespace Usuario
{
    public partial class App : Application
    {
        public static AzureDataService AzureService;
        public App()
        {
            // InitializeComponent();
            AzureService = new AzureDataService();
            MainPage = new Carrusel();
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
