using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HouseShell.Services;
using HouseShell.Views;
using HouseShell.Models;

namespace HouseShell
{
    public partial class App : Application
    {
        public IDataStore<House> DataStore;
        public App()
        {
            InitializeComponent();

#if DEBUG
#pragma warning disable 0618
            Application.LogWarningsToApplicationOutput = true;
#pragma warning restore 0618
            // Not yet available
            //Application.LogWarningsListener = warning => Debug.WriteLine($"{warning.Category}: {warning.Message}");
#endif

            DataStore = new HouseDataStore();

            MainPage = new AppShell();
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
