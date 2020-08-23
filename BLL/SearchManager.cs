using StockMS.DAL;
using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.BLL
{
    public class SearchManager
    {
        SearchGateway searchGateway;

        public SearchManager()
        {
            searchGateway = new SearchGateway();
        }

        // search by company and category both
        public List<SearchItemViewModel> GetSearchItemByCompanyAndCategoryBoth(int companyId, int categoryId)
        {
            return searchGateway.GetSearchItemByCompanyAndCategoryBoth(companyId, categoryId);
        }

        // search by category
        public List<SearchItemViewModel> GetSearchItemByCategory(int categoryId)
        {
            return searchGateway.GetSearchItemByCategory(categoryId);
        }

        // search by company
        public List<SearchItemViewModel> GetSearchItemByCompany(int companyId)
        {
            return searchGateway.GetSearchItemByCompany(companyId);
        }

        // get Item sold item by date (search)
        public List<SearchSoldItemViewModel> GetSoldItemByDate(string fromDate, string toDate)
        {
            return searchGateway.GetSoldItemByDate(fromDate, toDate);
        }
    }
}