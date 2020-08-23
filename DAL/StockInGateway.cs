using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockMS.DAL
{
    public class StockInGateway : CommonGateway
    {
        private int stockInQuantity = 0;
        // save on stock in table
        public int Save(StockIn stockIn)
        {
            Connection.Open();

            string query = "INSERT INTO StockIn VALUES (@companyId, @itemId, @stockInQuantity)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@companyId", stockIn.CompanyId);
            Command.Parameters.Add("@itemId", stockIn.ItemId);
            Command.Parameters.Add("@stockInQuantity", stockIn.StockInQuantity);

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;

        }

        // get total stock in quantity
        public int GetTotalStockInQuantity()
        {
            Connection.Open();

            string query = "SELECT SUM(StockInQuantity) AS StockQuantity FROM StockIn";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                stockInQuantity = Convert.ToInt32(Reader["StockQuantity"]);
            }

            Reader.Close();
            Connection.Close();

            return stockInQuantity;
        }
    }
}