using HouseShell.Models;
using HouseShell.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HouseShell.ViewModels
{
    public class HousesViewModel : BaseViewModel
    {
        public ObservableCollection<House> Houses { get; set; }
        public Command LoadHousesCommand { get; set; }
        public IDataStore<House> DataStore => DependencyService.Get<IDataStore<House>>() ?? new HouseDataStore();

        public HousesViewModel()
        {
            Title = "Browse";
            Houses = new ObservableCollection<House>();
            LoadHousesCommand = new Command(async () => await ExecuteLoadHousesCommand());
        }
        async Task ExecuteLoadHousesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Houses.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var House in items)
                {
                    Houses.Add(House);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
