using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockMS.DAL
{
    public class ItemGateway:CommonGateway
    {
        private int stockInQuantity = 0;
        // save item
        public int Save(Items item)
        {
            Connection.Open();

            string query = "INSERT INTO Items VALUES (@categoryId, @companyId, @itemName, @reorderLevel, @availableQuantity)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@categoryId", item.CategoryId);
            Command.Parameters.AddWithValue("@companyId", item.CompanyId);
            Command.Parameters.AddWithValue("@itemName", item.ItemName);
            Command.Parameters.AddWithValue("@reorderLevel", item.ReorderLevel);
            Command.Parameters.AddWithValue("@availableQuantity", item.AvailableQuantity);

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        // check if item is available or not
        public bool CheckItemExists(Items item)
        {
            Connection.Open();

            string query = "SELECT * FROM Items WHERE CategoryId = @categoryId and CompanyId = @companyId and ItemName = @itemName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@categoryId", item.CategoryId);
            Command.Parameters.AddWithValue("@companyId", item.CompanyId);
            Command.Parameters.AddWithValue("@itemName", item.ItemName);

            Reader = Command.ExecuteReader();

            bool isExists = Reader.HasRows;

            Connection.Close();

            return isExists;

        }

        // get item by company
        public List<Items> GetItemByCompany(int companyId)
        {
            Connection.Open();

            string query = "SELECT * FROM Items WHERE CompanyId = @companyId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@companyId", companyId);

            Reader = Command.ExecuteReader();

            List<Items> items = new List<Items>();

            while (Reader.Read())
            {
                Items item = new Items();

                item.Id = Convert.ToInt32(Reader["Id"]);
                item.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                item.ItemName = Reader["ItemName"].ToString();
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);

                items.Add(item);
            }

            Reader.Close();
            Connection.Close();

            return items;

        }

        // get item detail by itemclick
        public Items GetItemByItemAndCompany(int companyId, int itemId)
        {
            Connection.Open();

            string query = "SELECT * FROM Items WHERE CompanyId = @companyId AND Id = @id";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@companyId", companyId);
            Command.Parameters.AddWithValue("@id", itemId);

            Reader = Command.ExecuteReader();

            Items aItem = new Items();

            while (Reader.Read())
            {
                aItem.Id = Convert.ToInt32(Reader["Id"]);
                aItem.CategoryId = Convert.ToInt32(Reader["CategoryId"]);
                aItem.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                aItem.ItemName = Reader["ItemName"].ToString();
                aItem.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                aItem.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);

            }

            Reader.Close();
            Connection.Close();

            return aItem;

        }

        // update available quantity by stock in
        public int UpdateAvailableQuantityByItemIdAndCompany(StockIn stockIn, int totalQuantity)
        {
            Connection.Open();

            string query = "UPDATE Items SET AvailableQuantity = @availableQuantity WHERE Id=@id and CompanyId = @companyId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@availableQuantity", totalQuantity);
            Command.Parameters.AddWithValue("@id", stockIn.ItemId);
            Command.Parameters.AddWithValue("@companyId", stockIn.CompanyId);

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;

        }

        // get item and company name by itemId
        public TemporaryTable GetItemNameAndCompanyNameByItemId(int itemId)
        {
            Connection.Open();

            string query = "SELECT ItemName, CompanyName FROM Items, Company WHERE" +
                " Items.CompanyId = Company.Id and Items.Id = @itemId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@itemId", itemId);

            Reader = Command.ExecuteReader();

            TemporaryTable tempTable = new TemporaryTable();


            while (Reader.Read())
            {
                tempTable.ItemName = Reader["ItemName"].ToString();
                tempTable.CompanyName = Reader["CompanyName"].ToString();
            }

            Reader.Close();
            Connection.Close();

            return tempTable;

        }

        // update available quantity by stock in
        public int UpdateAvailableQuantityByItemIdAndCompanyOfStockOut(StockOut stockOut, int totalQuantity)
        {
            Connection.Open();

            string query = "UPDATE Items SET AvailableQuantity = @availableQuantity WHERE Id=@id and CompanyId = @companyId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@availableQuantity", totalQuantity);
            Command.Parameters.AddWithValue("@id", stockOut.ItemId);
            Command.Parameters.AddWithValue("@companyId", stockOut.CompanyId);

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;

        }


        // get available item quantity by id and company id
        public int GetAvailableQuantity(StockOut stockOut)
        {
            Connection.Open();

            string query = "SELECT AvailableQuantity FROM Items WHERE Id = @id and CompanyId = @companyId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", stockOut.ItemId);
            Command.Parameters.AddWithValue("@companyId", stockOut.CompanyId);

            Reader = Command.ExecuteReader();
            int quantity = 0;

            while (Reader.Read())
            {
                quantity = Convert.ToInt32(Reader["AvailableQuantity"]);
            }

            Reader.Close();
            Connection.Close();

            return quantity;
        }

        //get all items
        public List<ItemViewModel> GetItem()
        {
            Connection.Open();

            string query =
                "SELECT CategoryName as Category, CompanyName as Company, ItemName, ReorderLevel," +
                " AvailableQuantity FROM Items INNER JOIN Company ON Items.CompanyId = Company.Id INNER JOIN " +
                "Category ON Items.CategoryId = Category.Id";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();

            List<ItemViewModel> items = new List<ItemViewModel>();

            while (Reader.Read())
            {
                ItemViewModel item = new ItemViewModel();

                item.CompanyName = Reader["Company"].ToString();
                item.CategoryName = Reader["Category"].ToString();
                item.ItemName = Reader["ItemName"].ToString();
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);

                items.Add(item);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }

        // get total items
        public int GetTotalItems()
        {
            Connection.Open();

            string query = "SELECT COUNT(Id) AS Quantity FROM Items";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                stockInQuantity = Convert.ToInt32(Reader["Quantity"]);
            }

            Reader.Close();
            Connection.Close();

            return stockInQuantity;
        }

    }
}