using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.Models
{
    public class SoldItemViewModel
    {
        public string CompanyName { get; set; }
        public string Item { get; set; }
        public string Date { get; set; }
        public int Quantity { get; set; }
    }
}