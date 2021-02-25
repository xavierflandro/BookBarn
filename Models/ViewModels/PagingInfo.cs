using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int Totalpages => (int)Math.Ceiling((decimal)TotalNumItems / ItemsPerPage);  //casts TotalNumItems as dec in order to calc dec, then to ceiling to yield int (but still dec), then cast that int dec as decimal

    }
}
