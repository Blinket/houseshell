using HouseShell.Views;
using Plugin.StoreReview;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HouseShell
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("house", typeof(HouseDetailPage));
            //Routing.RegisterRoute("houses", typeof(HousesPage));
        }
        protected override bool OnBackButtonPressed()
        {
            var currentContent = CurrentItem?.CurrentItem;
            if (currentContent != null && currentContent.Stack.Count > 1)
            {
                currentContent.Navigation.PopAsync();
                return true;
            }
            Shell.Current.FlyoutIsPresented = true;
            return true;
        }

        private void RateApp_Click(object sender, EventArgs e)
        {
            string AppId = "";

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    AppId = "9999999999"; // Insert your app id here
                    break;

                case Device.Android:
                    AppId = "com.pluralsight.kandl";
                    break;

                default:
                    break;
            }
            Shell.Current.FlyoutIsPresented = false;
            CrossStoreReview.Current.OpenStoreReviewPage(AppId);
        }

        private void OpenUrl(string url)
        {
            Shell.Current.FlyoutIsPresented = false;
            Device.OpenUri(new Uri(url));
        }

        private void Help_Click(object sender, EventArgs e)
        {
            OpenUrl("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/");
        }

        private void Tos_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.pluralsight.com/terms");
        }

        private void Privacy_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.pluralsight.com/privacy");
        }

    }
}
