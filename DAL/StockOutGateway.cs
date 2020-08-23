using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockMS.DAL
{
    public class StockOutGateway : CommonGateway
    {
        private int stockOutQuantity = 0;
        private int soldItems = 0;
        // for save as sell on stock out
        public int SaveSell(StockOut stockOut)
        {
            Connection.Open();

            string query = "INSERT INTO StockOut VALUES (@companyId, @itemId, @date, @stockOutQuantity,'Sold')";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@companyId", stockOut.CompanyId);
            Command.Parameters.Add("@itemId", stockOut.ItemId);
            Command.Parameters.Add("@date", stockOut.Date);
            Command.Parameters.Add("@stockOutQuantity", stockOut.StockOutQuantity);
            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }


        // for save as damage on stock out
        public int SaveDamage(StockOut stockOut)
        {
            Connection.Open();

            string query = "INSERT INTO StockOut VALUES (@companyId, @itemId, @date, @stockOutQuantity,'Damage')";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@companyId", stockOut.CompanyId);
            Command.Parameters.Add("@itemId", stockOut.ItemId);
            Command.Parameters.Add("@date", stockOut.Date);
            Command.Parameters.Add("@stockOutQuantity", stockOut.StockOutQuantity);

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        // for save as lost on stock out
        public int SaveLost(StockOut stockOut)
        {
            Connection.Open();

            string query = "INSERT INTO StockOut VALUES (@companyId, @itemId, @date, @stockOutQuantity,'Lost')";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@companyId", stockOut.CompanyId);
            Command.Parameters.Add("@itemId", stockOut.ItemId);
            Command.Parameters.Add("@date", stockOut.Date);
            Command.Parameters.Add("@stockOutQuantity", stockOut.StockOutQuantity);

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        // get total stockOut quantity
        public int GetTotalStockOutQuantity()
        {
            Connection.Open();

            string query = "SELECT SUM(StockOutQuantity) as Quantity FROM StockOut";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                stockOutQuantity = Convert.ToInt32(Reader["Quantity"]);
            }

            Reader.Close();
            Connection.Close();

            return stockOutQuantity;
        }

        // get total sold item
        public int GetTotalSoldItems()
        {
            Connection.Open();

            string query = "SELECT SUM(StockOutQuantity) AS Quantity FROM StockOut WHERE Type = 'Sold'";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                soldItems = Convert.ToInt32(Reader["Quantity"]);
            }

            Reader.Close();
            Connection.Close();

            return soldItems;
        }

        // get sold items
        public List<SoldItemViewModel> GetAllSoldItems()
        {
            Connection.Open();

            string query = "SELECT Company.CompanyName AS Company, Items.ItemName as Item, StockOut.Date AS Date, StockOut.StockOutQuantity AS Quantity FROM StockOut, Company, Items WHERE Company.Id = StockOut.CompanyId AND Items.Id = StockOut.ItemId AND StockOut.Type = 'Sold' ORDER BY Date DESC";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();

            List<SoldItemViewModel> soldItems = new List<SoldItemViewModel>();

            while (Reader.Read())
            {
                SoldItemViewModel soldItem = new SoldItemViewModel();

                soldItem.CompanyName = Reader["Company"].ToString();
                soldItem.Item = Reader["Item"].ToString();
                soldItem.Date = Reader["Date"].ToString();
                soldItem.Quantity = Convert.ToInt32(Reader["Quantity"]);

                soldItems.Add(soldItem);
            }

            Reader.Close();
            Connection.Close();

            return soldItems;
        }
    }
}