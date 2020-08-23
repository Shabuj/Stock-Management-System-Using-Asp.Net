using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockMS.DAL
{
    public class SearchGateway : CommonGateway
    {
        public List<SearchItemViewModel> GetSearchItemByCompanyAndCategoryBoth(int companyId, int categoryId)
        {
            Connection.Open();

            string query = "SELECT ItemName,AvailableQuantity,ReorderLevel,CompanyName,CategoryName FROM Items, Company,Category WHERE Items.CompanyId = Company.Id and Items.CategoryId = @categoryId and Items.CompanyId= @companyId and Category.Id = @categoryId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@categoryId", categoryId);
            Command.Parameters.Add("@companyId", companyId);

            Reader = Command.ExecuteReader();

            List<SearchItemViewModel> items = new List<SearchItemViewModel>();

            // for serial
            int count = 0;

            while (Reader.Read())
            {
                SearchItemViewModel itemViewModel = new SearchItemViewModel();

                count++;

                itemViewModel.SL = count;
                itemViewModel.ItemName = Reader["ItemName"].ToString();
                itemViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                itemViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                itemViewModel.CompanyName = Reader["CompanyName"].ToString();
                itemViewModel.CategoryName = Reader["CategoryName"].ToString();

                items.Add(itemViewModel);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }

        // search by company
        public List<SearchItemViewModel> GetSearchItemByCompany(int companyId)
        {
            Connection.Open();

            string query = "SELECT ItemName,AvailableQuantity,ReorderLevel,CompanyName  FROM Items, Company WHERE Items.CompanyId = Company.Id and Items.CompanyId= @companyId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@companyId", companyId);

            Reader = Command.ExecuteReader();

            List<SearchItemViewModel> items = new List<SearchItemViewModel>();

            // for serial
            int count = 0;

            while (Reader.Read())
            {
                SearchItemViewModel itemViewModel = new SearchItemViewModel();

                count++;

                itemViewModel.SL = count;
                itemViewModel.ItemName = Reader["ItemName"].ToString();
                itemViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                itemViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                itemViewModel.CompanyName = Reader["CompanyName"].ToString();

                items.Add(itemViewModel);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }

        // search by category
        public List<SearchItemViewModel> GetSearchItemByCategory(int categoryId)
        {
            Connection.Open();

            string query = "SELECT ItemName,AvailableQuantity,ReorderLevel,CompanyName,CategoryName FROM Items, Company WHERE Items.CompanyId = Company.Id and Items.CategoryId = @categoryId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@categoryId", categoryId);
            Reader = Command.ExecuteReader();

            List<SearchItemViewModel> items = new List<SearchItemViewModel>();

            // for serial
            int count = 0;

            while (Reader.Read())
            {
                SearchItemViewModel itemViewModel = new SearchItemViewModel();

                count++;

                itemViewModel.SL = count;
                itemViewModel.ItemName = Reader["ItemName"].ToString();
                itemViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                itemViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                itemViewModel.CompanyName = Reader["CompanyName"].ToString();
                itemViewModel.CategoryName = Reader["CategoryName"].ToString();

                items.Add(itemViewModel);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }

        // get Item sold item by date (search)
        public List<SearchSoldItemViewModel> GetSoldItemByDate(string fromDate, string toDate)
        {
            Connection.Open();

            string query = "SELECT Items.ItemName as ItemName," +
                " sum(StockOutQuantity) as TotalQuantity FROM Items, StockOut, Company" +
                " WHERE StockOut.Date>= @fromDate and StockOut.Date<= @toDate and " +
                "StockOut.Type = 'Sold' and Items.Id = StockOut.ItemId and Company.Id = Items.CompanyId" +
                " and Company.Id = Stockout.CompanyId Group by StockOut.CompanyId, StockOut.ItemId" +
                ",Company.CompanyName,Company.Id, Items.ItemName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@fromDate", fromDate);
            Command.Parameters.Add("@toDate", toDate);

            Reader = Command.ExecuteReader();

            List<SearchSoldItemViewModel> items = new List<SearchSoldItemViewModel>();

            // for serial
            int count = 0;

            while (Reader.Read())
            {
                SearchSoldItemViewModel itemViewModel = new SearchSoldItemViewModel();

                count++;

                itemViewModel.Sl = count;
                itemViewModel.ItemName = Reader["ItemName"].ToString();

                itemViewModel.Quantity = Convert.ToInt32(Reader["TotalQuantity"]);

                items.Add(itemViewModel);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }
    }
}