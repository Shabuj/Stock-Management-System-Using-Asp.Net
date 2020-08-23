using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.Models
{
    public class StockIn
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public int StockInQuantity { get; set; }
    }
}