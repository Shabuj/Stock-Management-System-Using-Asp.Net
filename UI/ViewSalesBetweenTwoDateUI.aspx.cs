using StockMS.BLL;
using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockMS.UI
{
    public partial class ViewSalesBetweenTwoDateUI : System.Web.UI.Page
    {
        SearchManager searchManager = new SearchManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string fromDate = String.Format("{0}", Request.Form["fromDatePicker"]);
            string toDate = String.Format("{0}", Request.Form["toDatePicker"]);

            if (fromDate.Equals("") && toDate.Equals(""))
            {
                outputErrorLabel.Text = "Enter From and To Date";
            }
            else if (fromDate.Equals(""))
            {
                outputErrorLabel.Text = "Enter From Date";
            }
            else if (toDate.Equals(""))
            {
                outputErrorLabel.Text = "Enter To Date";
            }
            else
            {
                SearchByDate(fromDate, toDate);
            }
        }

        public void SearchByDate(string fromDate, string toDate)
        {
            string fromYear = fromDate.Substring(6, 4);
            string fromMonth = fromDate.Substring(0, 2);
            string fromDay = fromDate.Substring(3, 2);

            string toYear = toDate.Substring(6, 4);
            string toMonth = toDate.Substring(0, 2);
            string toDay = toDate.Substring(3, 2);

            string fullFromDate = fromYear + "/" + fromMonth + "/" + fromDay;
            string fullToDate = toYear + "/" + toMonth + "/" + toDay;


            DateTime fromDateTime = DateTime.Parse(fullFromDate);
            DateTime toDateTime = DateTime.Parse(fullToDate);

            if (fromDateTime.Date > toDateTime.Date)
            {
                outputErrorLabel.Text = "Enter valid date";
            }
            else
            {
                // change here
                List<SearchSoldItemViewModel> itemList = searchManager.GetSoldItemByDate(fullFromDate, fullToDate);
                BindWithDataGridView(itemList);
            }

        }

        public void BindWithDataGridView(List<SearchSoldItemViewModel> itemList)
        {
            if (itemList.Count() > 0)
            {
                searchGridView.DataSource = itemList;
                searchGridView.DataBind();
                outputErrorLabel.Text = String.Empty;
            }
            else
            {
                outputErrorLabel.Text = "No items found";
            }
        }
    }
}