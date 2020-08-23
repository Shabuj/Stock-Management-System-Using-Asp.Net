using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockMS.DAL
{
    public class CategoryGateway:CommonGateway
    {
        public int SaveCategory(Category category)
        {
            Connection.Open();
            string query = "INSERT INTO Category VALUES(@CategoryName)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;

        }

       public bool IsCategoryNameExists(string categoryName)
        {
            Connection.Open();

            string query = "SELECT * FROM Category WHERE CategoryName = @categoryName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@categoryName", categoryName);

            Reader = Command.ExecuteReader();

            bool isExists = Reader.HasRows; // returns true if rows exists else return false

            Connection.Close();

            return isExists;
        }

        public List<Category> GetAllCategory()
        {
            Connection.Open();
            string query = "SELECT * FROM Category";
            Command = new SqlCommand(query, Connection);

            Reader = Command.ExecuteReader();

            int serial = 0;
            List<Category> categories = new List<Category>();

            while (Reader.Read())
            {
                Category category = new Category();
                serial++;

                category.SL = serial;
                category.Id = Convert.ToInt32(Reader["Id"]);
                category.CategoryName = Reader["CategoryName"].ToString();

                categories.Add(category);
            }

            Reader.Close();
            Connection.Close();

            return categories;
        }
        public Category GetCategoryById(int id)
        {
            Connection.Open();

            string query = "SELECT * FROM Category WHERE Id = @id";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);

            Reader = Command.ExecuteReader();
            Category category = new Category();

            while (Reader.Read())
            {
                category.Id = Convert.ToInt32(Reader["Id"]);
                category.CategoryName = Reader["CategoryName"].ToString();
            }

            Reader.Close();
            Connection.Close();

            return category;
        }

        // update category by id
        public int UpdateCategoryNameById(Category category)
        {
            Connection.Open();

            string query = "UPDATE Category SET CategoryName = @categoryName WHERE Id = @id";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@categoryName", category.CategoryName);
            Command.Parameters.AddWithValue("@id", category.Id);

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
    }
}