using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HouseShell.Models;

namespace HouseShell.Services
{
    public class HouseSearchHandler : SearchHandler
    {
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                var val = newValue.ToLower();
                var DataStore = ((App)App.Current).DataStore;

                ItemsSource = DataStore.GetItemsAsync().Result
                    .ToList<House>()
                    .Where(h => ((h.HouseType.ToLower().Contains(val)) ||
                        (h.Address1.ToLower().Contains(val))
                    ));
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            ItemsSource = null;

            // work around for bug 5713 on iOS
            // https://github.com/xamarin/Xamarin.Forms/issues/5713
            await Task.Delay(400);
            // Note: strings will be URL encoded for navigation (e.g. "Blue Monkey" becomes "Blue%20Monkey"). Therefore, decode at the receiver.
            await Shell.Current.GoToAsync($"//houses/house?id={((House)item).ID}", true);
        }
    }
}
