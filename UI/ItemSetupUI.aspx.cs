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
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // load the category and company at the page starting
                GetAllCategoryAndBindWithCategoryDropDown();
                GetAllCompanyAndBindWithCompanyDropDown();

            }
        }

        protected void saveButton_OnClick(object sender, EventArgs e)
        {

            // check drop down values
            if (categoryDropDownList.Text.Equals("--Select Category--") && companyDropDownList.Text.Equals("--Select Company--"))
            {
                noCategorySelectDropDownError.Text = "Select one category";
                noCompanySelectDropDownError.Text = "Select one company";
                emptyItemNameTextboxError.Text = "";
                emptyReorderLevelTextBoxError.Text = "";
                messageLabel.Text = "";
            }
            else if (categoryDropDownList.Text.Equals("--Select Category--"))
            {
                noCategorySelectDropDownError.Text = "Select one category";
                noCompanySelectDropDownError.Text = "";
                emptyItemNameTextboxError.Text = "";
                emptyReorderLevelTextBoxError.Text = "";
                messageLabel.Text = "";
            }
            else if (companyDropDownList.Text.Equals("--Select Company--"))
            {
                noCategorySelectDropDownError.Text = "";
                noCompanySelectDropDownError.Text = "Select one company";
                emptyItemNameTextboxError.Text = "";
                emptyReorderLevelTextBoxError.Text = "";
                messageLabel.Text = "";
            }
            else
            {
                // first check the text box is empty or not
                if (itemNameTextBox.Text.Equals("") && reorderLevelTextBox.Text.Equals(""))
                {
                    emptyItemNameTextboxError.Text = "Enter Item Name";
                    emptyReorderLevelTextBoxError.Text = "Enter Reorder level";
                    noCategorySelectDropDownError.Text = "";
                    noCompanySelectDropDownError.Text = "";
                    messageLabel.Text = "";
                }
                else if (itemNameTextBox.Text.Equals(""))
                {
                    emptyItemNameTextboxError.Text = "Enter Item Name";
                    noCategorySelectDropDownError.Text = "";
                    noCompanySelectDropDownError.Text = "";
                    emptyReorderLevelTextBoxError.Text = "";
                    messageLabel.Text = "";
                }
                else if (reorderLevelTextBox.Text.Equals(""))
                {
                    emptyItemNameTextboxError.Text = "";
                    noCategorySelectDropDownError.Text = "";
                    noCompanySelectDropDownError.Text = "";
                    emptyReorderLevelTextBoxError.Text = "Enter Reorder level";
                    messageLabel.Text = "";
                }
                else
                {
                    if (reorderLevelTextBox.Text.All(char.IsDigit))
                    {
                        Items item = new Items();
                        item.CategoryId = Convert.ToInt32(categoryDropDownList.Text);
                        item.CompanyId = Convert.ToInt32(companyDropDownList.Text);
                        item.ItemName = itemNameTextBox.Text;
                        item.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);

                        if (item.ReorderLevel < 0)
                        {
                            emptyReorderLevelTextBoxError.Text = "Enter Reorder level properly";
                            noCategorySelectDropDownError.Text = "";
                            noCompanySelectDropDownError.Text = "";
                            emptyItemNameTextboxError.Text = string.Empty;
                            messageLabel.Text = string.Empty;
                        }

                        else
                        {


                            // save item
                            messageLabel.Text = itemManager.Save(item);


                            // make text box empty
                            itemNameTextBox.Text = "";
                            reorderLevelTextBox.Text = "";
                            emptyItemNameTextboxError.Text = "";
                            emptyReorderLevelTextBoxError.Text = "";
                            noCategorySelectDropDownError.Text = "";
                            noCompanySelectDropDownError.Text = "";
                        }
                    }
                    else
                    {
                        emptyReorderLevelTextBoxError.Text = "Enter quantity";
                        emptyItemNameTextboxError.Text = "";
                        noCategorySelectDropDownError.Text = "";
                        noCompanySelectDropDownError.Text = "";
                    }
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

            categoryDropDownList.Items.Insert(0, "--Select Category--");
        }

        // get all company and bind with dropdown
        private void GetAllCompanyAndBindWithCompanyDropDown()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompany();
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();

            companyDropDownList.Items.Insert(0, "--Select Company--");
        }
    }
}