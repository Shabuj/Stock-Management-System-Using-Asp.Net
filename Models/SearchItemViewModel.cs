using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.Models
{
    public class SearchItemViewModel
    {
        public int SL { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }
    }
}