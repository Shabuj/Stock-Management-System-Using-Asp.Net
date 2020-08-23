using StockMS.DAL;
using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.BLL
{
    public class StockOutManager
    {
        StockOutGateway stockOutGateway = new StockOutGateway();

        // for save as sell on stock out
        public bool SaveSell(StockOut stockOut)
        {
            int rowsAffected = stockOutGateway.SaveSell(stockOut);

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // for save as damage on stock out
        public bool SaveDamage(StockOut stockOut)
        {
            int rowsAffected = stockOutGateway.SaveDamage(stockOut);

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // for save as lost on stock out
        public bool SaveLost(StockOut stockOut)
        {
            int rowsAffected = stockOutGateway.SaveLost(stockOut);

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // get total sold item
        public int GetTotalSoldItems()
        {
            return stockOutGateway.GetTotalSoldItems();
        }

        // get total stockOut quantity
        public int GetTotalStockOutQuantity()
        {
            return stockOutGateway.GetTotalStockOutQuantity();
        }

        // get sold items
        public List<SoldItemViewModel> GetAllSoldItems()
        {
            return stockOutGateway.GetAllSoldItems();
        }
    }
}