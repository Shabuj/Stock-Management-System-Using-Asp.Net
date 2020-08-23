using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.Models
{
    [Serializable]
    public class StockOut
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public string Date { get; set; }
        public int StockOutQuantity { get; set; }
        public string Type { get; set; }
    }
}