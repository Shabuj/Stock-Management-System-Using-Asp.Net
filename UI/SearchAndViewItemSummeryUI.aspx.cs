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
    public partial class SearchAndViewItemSummeryUI : System.Web.UI.Page
    {

        CategoryManager categoryManager = new CategoryManager();
        CompanyManager companyManager = new CompanyManager();
        SearchManager searchManager = new SearchManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // load the category and company at the page starting
                GetAllCategoryAndBindWithCategoryDropDown();
                GetAllCompanyAndBindWithCompanyDropDown();

            }

        }

        protected void searchButtton_OnClick(object sender, EventArgs e)
        {
            // check which drop down is selected
            if (companyDropDownList.Text.Equals("--Select Company--") && categoryDropDownList.Text.Equals("--Select Category--"))
            {
                errorLabel.Text = "Please select one of the drop down";
                BindWithDataGrid(null);
            }
            else if (companyDropDownList.Text.Equals("--Select Company--"))
            {
                // get by category
                int categoryId = Convert.ToInt32(categoryDropDownList.Text);
                List<SearchItemViewModel> items = searchManager.GetSearchItemByCategory(categoryId);

                if (items.Count > 0)
                {
                    BindWithDataGrid(items);
                    errorLabel.Text = "";
                }
                else
                {
                    errorLabel.Text = "No items found";
                    BindWithDataGrid(null);
                }

            }
            else if (categoryDropDownList.Text.Equals("--Select Category--"))
            {
                //get by company
                int companyId = Convert.ToInt32(companyDropDownList.Text);
                List<SearchItemViewModel> items = searchManager.GetSearchItemByCompany(companyId);

                if (items.Count > 0)
                {
                    BindWithDataGrid(items);
                    errorLabel.Text = "";
                }
                else
                {
                    errorLabel.Text = "No items found";
                    BindWithDataGrid(null);
                }

            }


            else
            {
                // get by company and category both
                int categoryId = Convert.ToInt32(categoryDropDownList.Text);
                int companyId = Convert.ToInt32(companyDropDownList.Text);


                List<SearchItemViewModel> items = searchManager.GetSearchItemByCompanyAndCategoryBoth(companyId, categoryId);
                if (items.Count > 0)
                {
                    BindWithDataGrid(items);
                    errorLabel.Text = "";
                }
                else
                {
                    errorLabel.Text = "No items found";
                    BindWithDataGrid(null);
                }


            }
        }

        // get all category and bind with dropdown
        private void GetAllCategoryAndBindWithCategoryDropDown()
        {
            categoryDropDownList.DataSource = categoryManager.GetAllCategory();
            categoryDropDownList.DataTextField = "CategoryName";
            categoryDropDownList.DataValueField = "Id";
            categoryDropDownList.DataBind();

            // default selection
            categoryDropDownList.Items.Insert(0, "--Select Category--");
        }

        // get all company and bind with dropdown
        private void GetAllCompanyAndBindWithCompanyDropDown()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompany();
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();

            // default selection
            companyDropDownList.Items.Insert(0, "--Select Company--");
        }

        // Bind data with gridview
        public void BindWithDataGrid(List<SearchItemViewModel> items)
        {
            showSearchedResultGridView.DataSource = items;
            showSearchedResultGridView.DataBind();

        }
    }
}