using HouseShell.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseShell.ViewModels
{
    public class HouseViewModel : BaseViewModel
    {
        public House House { get; set; }

        public HouseViewModel(House house = null)
        {
            Title = house?.Address1;
            House = house;
        }
    }
}
