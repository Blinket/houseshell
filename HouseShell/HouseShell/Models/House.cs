using System;
using System.Collections.Generic;
using System.Text;

namespace HouseShell.Models
{
    public class House
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ListedBy { get; set; }
        public string HouseType { get; set; }
        public string ImageUrl { get; set; }
    }
}
