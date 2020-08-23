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
    public partial class StockInUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            // load company name on page load
            if (!IsPostBack)
            {

                GetCompanyAndBindWithDropDown();
                // default selection
                itemDropDownList.Items.Insert(0, "--Select Item--");

            }

        }

        protected void saveButton_OnClick(object sender, EventArgs e)
        {
            // save on stock in and update on available quantity
            // get selected item details
            Items item = (Items)ViewState["ItemVS"];

            // check any valid item selected or not
            if (item != null)
            {
                if (stockInQuantityTextBox.Text.Equals("") || companyDropDownList.Text.Equals("--Select Company--") || itemDropDownList.Text.Equals("--Select Item--"))
                {
                    quantityEmptyTextBoxMessage.Text = "Enter quantity or Select company or Item properly";
                    messageLabel.Text = string.Empty;
                }


                else
                {
                    if (stockInQuantityTextBox.Text.All(char.IsDigit))
                    {
                        int stockInQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                        if (stockInQuantity < 0)

                        {
                            quantityEmptyTextBoxMessage.Text = "Enter quantity properly";
                            messageLabel.Text = string.Empty;

                        }

                        else
                        {


                            StockIn stockIn = new StockIn();
                            stockIn.ItemId = item.Id;
                            stockIn.CompanyId = item.CompanyId;
                            stockIn.StockInQuantity = stockInQuantity;

                            // get previous quantity of item and update the quantity
                            int previousAvailableQuantity = item.AvailableQuantity;
                            int newAvailableQuantity = previousAvailableQuantity + stockInQuantity;

                            quantityEmptyTextBoxMessage.Text = "";

                            // save on StockIn table and update on available quantity
                            messageLabel.Text =
                                itemManager.UpdateAvailableQuantityByItemIdAndCompany(stockIn, newAvailableQuantity);
                            GoToPreviousState();
                        }
                    }
                    else
                    {
                        quantityEmptyTextBoxMessage.Text = "Enter quantity correctly";
                    }
                }
            }
            else
            {
                messageLabel.Text = "Select company and item properly";
            }
        }
        public void GetCompanyAndBindWithDropDown()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompany();
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();

            // default selection
            companyDropDownList.Items.Insert(0, "--Select Company--");

        }

        // get items by company
        public void GetItemAndBindWithDropDown(int companyId)
        {
            itemDropDownList.DataSource = itemManager.GetItemByCompany(companyId);
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataBind();

            // default selection
            itemDropDownList.Items.Insert(0, "--Select Item--");
        }


        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check selected input is valid or not
            if (companyDropDownList.Text.Equals("--Select Company--") && itemDropDownList.Text.Equals("--Select Item--"))
            {
                companySelectionErrorLabel.Text = "Select Correct Company";
                itemSelectionErrorLabel.Text = "Select Correct Item";
            }
            else if (companyDropDownList.Text.Equals("--Select Company--"))
            {
                // load page again when select fisrt item from Company
                Response.Redirect("StockInUI.aspx?Id=" + Request.QueryString["Id"], false);
            }
            else if (itemDropDownList.Text.Equals("--Select Item--"))
            {
                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "Select Correct Item";
                reorderLevelTextBox.Text = string.Empty;
                quantityTextBox.Text = string.Empty;
            }
            else
            {
                reorderLevelTextBox.Text = string.Empty;
                quantityTextBox.Text = string.Empty;

                // get item details
                int itemId = Convert.ToInt32(itemDropDownList.Text);
                int companyId = Convert.ToInt32(companyDropDownList.Text);

                // get item details by itemId and CompanyId
                Items item = itemManager.GetItemByItemAndCompany(companyId, itemId);

                reorderLevelTextBox.Text = item.ReorderLevel.ToString();
                quantityTextBox.Text = item.AvailableQuantity.ToString();

                // store item details on viewstate for use
                ViewState["ItemVS"] = item;

                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "";

            }


        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check selected input is valid or not
            if (companyDropDownList.Text.Equals("--Select Company--"))
            {
                // load page again when select fisrt item from Company
                Response.Redirect("StockInUI.aspx?Id=" + Request.QueryString["Id"], false);
            }
            else
            {
                reorderLevelTextBox.Text = string.Empty;
                quantityTextBox.Text = string.Empty;
                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "";

                // get Items by Company and bind it to the itemDropDown
                int companyId = Convert.ToInt32(companyDropDownList.Text);
                GetItemAndBindWithDropDown(companyId);
            }
        }

        // make page in previous state
        public void GoToPreviousState()
        {
            companyDropDownList.SelectedIndex = 0;
            itemDropDownList.SelectedIndex = 0;

            itemDropDownList.Items.Clear();
            itemDropDownList.Items.Insert(0, "--Select Item--");

            stockInQuantityTextBox.Text = string.Empty;
            reorderLevelTextBox.Text = string.Empty;
            quantityTextBox.Text = string.Empty;
        }
    }
}