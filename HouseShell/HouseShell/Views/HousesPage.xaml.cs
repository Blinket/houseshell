using HouseShell.Models;
using HouseShell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HouseShell.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HousesPage : ContentPage
    {
        HousesViewModel viewModel;
        public HousesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new HousesViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem is House house)
            {
                await Navigation.PushAsync(new HouseDetailPage(new HouseViewModel(house)));
            }
            (sender as ListView).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Houses.Count == 0)
                viewModel.LoadHousesCommand.Execute(null);
        }

    }
}