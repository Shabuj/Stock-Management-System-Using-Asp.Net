using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockMS.DAL
{
    public class CompanyGateway:CommonGateway
    {
        public int Save(Company company)
        {
            Connection.Open();

            string query = "INSERT INTO Company VALUES(@companyName)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@companyName", company.CompanyName);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;

        }

        // check if companyName already exists or not
        public bool IsCompanyNameExists(string companyName)
        {
            Connection.Open();

            string query = "SELECT * FROM Company WHERE CompanyName = @companyName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Add("@companyName", companyName);

            Reader = Command.ExecuteReader();

            bool isExists = Reader.HasRows;
            Connection.Close();

            return isExists;

        }

        //get All company for show
        public List<Company> GetAllCompany()
        {
            Connection.Open();

            string query = "SELECT * FROM Company order by Id";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();

            int serial = 0;
            List<Company> companies = new List<Company>();

            while (Reader.Read())
            {
                Company company = new Company();
                serial++;

                company.SL = serial;
                company.Id = Convert.ToInt32(Reader["Id"]);
                company.CompanyName = Reader["CompanyName"].ToString();
                companies.Add(company);

            }

            Reader.Close();
            Connection.Close();

            return companies;
        }
    }
}