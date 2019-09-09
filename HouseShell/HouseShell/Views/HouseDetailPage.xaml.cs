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
    [QueryProperty("ID", "id")]
    public partial class HouseDetailPage : ContentPage
    {
        HouseViewModel viewModel;
        public string ID
        {
            set
            {
                var DataStore = ((App)App.Current).DataStore;
                var house = DataStore.GetItemAsync(Uri.UnescapeDataString(value)).Result;

                viewModel = new HouseViewModel(house);

                BindingContext = viewModel;
            }
        }

        public HouseDetailPage(HouseViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public HouseDetailPage()
        {
            InitializeComponent();
        }
    }
}