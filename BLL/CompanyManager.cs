using StockMS.DAL;
using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.BLL
{
    public class CompanyManager
    {
        CompanyGateway companyGateway;

        public CompanyManager()
        {
            companyGateway = new CompanyGateway();
        }

        // save company
        public string Save(Company company)
        {
            // first check companyName is exists or not
            if (companyGateway.IsCompanyNameExists(company.CompanyName))
            {
                return "Company Name already exists";
            }
            else
            {
                // save company
                int rowAffected = companyGateway.Save(company);

                if (rowAffected > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }

        // get all company for show
        public List<Company> GetAllCompany()
        {
            return companyGateway.GetAllCompany();
        }
    }
}