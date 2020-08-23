using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.Models
{
    [Serializable]
    public class Items
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }
    }
}