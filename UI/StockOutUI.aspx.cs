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
    public partial class StockOutUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        StockOutManager stockOutManager = new StockOutManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            // load company name on form load
            if (!IsPostBack)
            {

                GetAndBindCompany();

            }

        }
        // load all company and bind with drop down
        public void GetAndBindCompany()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompany();
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();

            // default selection
            companyDropDownList.Items.Insert(0, "--Select Company--");

            // default selection on item
            itemDropDownList.DataSource = null;
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, "--Select Item--");
        }


        protected void addButton_OnClick(object sender, EventArgs e)
        {
            if (companyDropDownList.Text.Equals("--Select Company--") &&
                itemDropDownList.Text.Equals("--Select Item--") && stockOutQuantityTextBox.Text.Equals(""))
            {
                companySelectionErrorLabel.Text = "Select Company";
                itemSelectionErrorLabel.Text = "Select item";
                stockEmptyErrorLabel.Text = "Enter stock out quantity";
                outputLabel.Text = "";
            }
            else if (companyDropDownList.Text.Equals("--Select Company--") && stockOutQuantityTextBox.Text.Equals(""))
            {
                companySelectionErrorLabel.Text = "Select Company";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "Enter stock out quantity";
                outputLabel.Text = "";
            }
            else if (itemDropDownList.Text.Equals("--Select Item--") && stockOutQuantityTextBox.Text.Equals(""))
            {
                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "Select item";
                stockEmptyErrorLabel.Text = "Enter stock out quantity";
                outputLabel.Text = "";
            }
            else if (companyDropDownList.Text.Equals("--Select Company--"))
            {
                companySelectionErrorLabel.Text = "Select Company";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "";
            }
            else if (itemDropDownList.Text.Equals("--Select Item--"))
            {
                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "Select item";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "";
            }
            else if (stockOutQuantityTextBox.Text.Equals(""))
            {
                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "Enter stock out quantity";
                outputLabel.Text = "";
            }
            else if (companyDropDownList.Text.Equals("--Select Company--") &&
                     itemDropDownList.Text.Equals("--Select Item--"))
            {
                companySelectionErrorLabel.Text = "Select Company";
                itemSelectionErrorLabel.Text = "Select item";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "";
            }
            else
            {
                // get companyid, itemId, and stockout from UI control
                int companyId = Convert.ToInt32(companyDropDownList.Text);
                int itemId = Convert.ToInt32(itemDropDownList.Text);

                if (stockOutQuantityTextBox.Text.All(char.IsDigit))
                {
                    int stockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);

                    if (stockOutQuantity < 0)
                    {
                        stockEmptyErrorLabel.Text = "Enter quantity properly";
                    }
                    else
                    {

                        System.Diagnostics.Debug.WriteLine("Company Id: " + companyId + " Item id: " + itemId +
                                                           " Stock out : " + stockOutQuantity);

                        // check stockOut quantity is greater then availableQuantity
                        Items item = (Items)ViewState["ItemVS"];

                        System.Diagnostics.Debug.WriteLine("Item Id: " + item.Id + " CompanyId " + item.CompanyId +
                                                           " Avail : " + item.AvailableQuantity);

                        // copy and add this portion (start)
                        int availableQuantity = item.AvailableQuantity;

                        if (ViewState["StockOutListVS"] != null)
                        {
                            availableQuantity = availableQuantity - GetStockOutQuantity(item.Id);
                        }

                        System.Diagnostics.Debug.WriteLine("Avail: " + availableQuantity);

                        // copy and add this portion (end)

                        if (availableQuantity >= stockOutQuantity)
                        {
                            System.Diagnostics.Debug.Write("Yes");
                            // add data on List for temporary Table
                            AddStockListForTemporaryTable(item, companyId, itemId, stockOutQuantity);

                            // use the viewState of temporary table
                            List<StockOut> listStockOut = (List<StockOut>)ViewState["StockOutListVS"];

                            // get data for temporary table
                            List<TemporaryTable> temporaryTableList = GetDataForTemporaryTable(listStockOut);

                            // bind data with temporary table list
                            BindDataWithGridView(temporaryTableList);

                            // copy this also
                            availableQuantityTextBox.Text = (availableQuantity - stockOutQuantity).ToString();

                            companySelectionErrorLabel.Text = "";
                            itemSelectionErrorLabel.Text = "";
                            stockEmptyErrorLabel.Text = "";
                            outputLabel.Text = "";
                            stockNotAvailableErrorLabel.Text = "";
                            stockOutQuantityTextBox.Text = string.Empty;
                            companyDropDownList.Text = "--Select Company--";
                            itemDropDownList.Text = "--Select Item--";
                            itemDropDownList.Items.Clear();
                            itemDropDownList.Items.Insert(0, "--Select Item--");
                            reorderLevelTextBox.Text = string.Empty;
                            availableQuantityTextBox.Text = string.Empty;
                        }
                        else
                        {
                            System.Diagnostics.Debug.Write("No");


                            companySelectionErrorLabel.Text = "";
                            itemSelectionErrorLabel.Text = "";
                            stockEmptyErrorLabel.Text = "";
                            outputLabel.Text = "";
                            stockNotAvailableErrorLabel.Text = "Stock not available";
                        }
                    }
                }
                else
                {
                    stockEmptyErrorLabel.Text = "Enter correct quantity";
                }
            }
        }

        // copy this method
        public int GetStockOutQuantity(int itemId)
        {
            List<StockOut> items = (List<StockOut>)ViewState["StockOutListVS"];
            int quantity = 0;

            for (int i = 0; i < items.Count; i++)
            {
                if (itemId == items[i].ItemId)
                {
                    quantity = items[i].StockOutQuantity;
                }
            }

            return quantity;
        }

        // get data for temporary table
        private List<TemporaryTable> GetDataForTemporaryTable(List<StockOut> stockOutList)
        {
            List<TemporaryTable> temporaryTableList = new List<TemporaryTable>();

            // for serial no
            int count = 0;

            foreach (StockOut stockOut in stockOutList)
            {
                TemporaryTable tempTable = itemManager.GetItemNameAndCompanyNameByItemId(stockOut.ItemId);

                count++;

                tempTable.SL = count;
                tempTable.Quantity = stockOut.StockOutQuantity;


                temporaryTableList.Add(tempTable);
            }

            return temporaryTableList;
        }

        // add data on a list for temporaray table
        public void AddStockListForTemporaryTable(Items item, int companyId, int itemId, int stockOutQuantity)
        {

            // add to a StockOutList (for temporary)
            if (ViewState["StockOutListVS"] == null)
            {
                StockOut stockOut = new StockOut();
                List<StockOut> stockOutList = new List<StockOut>();

                stockOut.CompanyId = companyId;
                stockOut.ItemId = itemId;
                stockOut.Date = DateTime.Today.ToString("yyyy/MM/dd");
                stockOut.StockOutQuantity = stockOutQuantity;
                stockOut.Type = "No";

                stockOutList.Add(stockOut);

                // update viewState
                ViewState["StockOutListVS"] = stockOutList;
            }
            else
            {
                StockOut stockOut = new StockOut();
                List<StockOut> listStockOut = (List<StockOut>)ViewState["StockOutListVS"];

                int previousQuantity = 0;
                int index = -1;

                for (int i = 0; i < listStockOut.Count; i++)
                {
                    if (listStockOut[i].ItemId == itemId)
                    {
                        index = i;
                        previousQuantity = listStockOut[i].StockOutQuantity + stockOutQuantity;
                    }
                }

                if (index == -1)
                {
                    stockOut.CompanyId = companyId;
                    stockOut.ItemId = itemId;
                    stockOut.Date = DateTime.Today.ToString("yyyy/MM/dd");
                    stockOut.StockOutQuantity = stockOutQuantity;
                    stockOut.Type = "No";

                    listStockOut.Add(stockOut);
                }
                else
                {
                    listStockOut[index].StockOutQuantity = previousQuantity;
                }

                // update viewState
                ViewState["StockOutListVS"] = listStockOut;
            }
        }


        // bind data with temporary table list
        public void BindDataWithGridView(List<TemporaryTable> temporaryTableList)
        {
            addItemGridView.DataSource = temporaryTableList;
            addItemGridView.DataBind();
        }


        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!companyDropDownList.Text.Equals("--Select Company--"))
            {
                reorderLevelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;

                int companyId = Convert.ToInt32(companyDropDownList.Text);
                // get item by company
                GetItemAndBindWithDropDown(companyId);

                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "";
            }
            else
            {
                companySelectionErrorLabel.Text = "Select correct company";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "";

                reorderLevelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;
                itemDropDownList.Items.Clear();
                itemDropDownList.Items.Insert(0, "--Select Item--");
            }
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
            if (companyDropDownList.Text.Equals("--Select Company--") && itemDropDownList.Text.Equals("--Select Item--"))
            {
                companySelectionErrorLabel.Text = "Select correct company";
                itemSelectionErrorLabel.Text = "Select item";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "";

                reorderLevelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;
                itemDropDownList.Items.Clear();
                itemDropDownList.Items.Insert(0, "--Select Item--");
            }
            else if (companyDropDownList.Text.Equals("--Select Company--"))
            {
                companySelectionErrorLabel.Text = "Select correct company";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "";

                reorderLevelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;
                itemDropDownList.Items.Clear();
                itemDropDownList.Items.Insert(0, "--Select Item--");
            }
            else if (itemDropDownList.Text.Equals("--Select Item--"))
            {
                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "Select Item";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "";

                reorderLevelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;
            }
            else
            {
                reorderLevelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;

                // get item details
                int itemId = Convert.ToInt32(itemDropDownList.Text);
                int companyId = Convert.ToInt32(companyDropDownList.Text);

                // get item details by itemId and CompanyId
                Items item = itemManager.GetItemByItemAndCompany(companyId, itemId);

                reorderLevelTextBox.Text = item.ReorderLevel.ToString();
                availableQuantityTextBox.Text = item.AvailableQuantity.ToString();

                // store item details on viewstate for use
                ViewState["ItemVS"] = item;


                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "";

                // copy this portion (start)
                if (ViewState["StockOutListVS"] != null)
                {
                    int quantity = GetStockOutQuantity(itemId);

                    if (quantity <= 0)
                    {
                        availableQuantityTextBox.Text = item.AvailableQuantity.ToString();
                    }
                    else
                    {
                        availableQuantityTextBox.Text = (item.AvailableQuantity - GetStockOutQuantity(itemId)).ToString();
                    }
                }
                // (end)

            }
        }

        // for sell added item
        protected void sellButton_Click(object sender, EventArgs e)
        {
            // get added items list from viewState
            List<StockOut> listStockOut = (List<StockOut>)ViewState["StockOutListVS"];
            int count = 0;

            if (listStockOut == null)
            {
                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "Add at least one element";
            }
            else
            {
                foreach (StockOut stockOutItem in listStockOut)
                {
                    if (stockOutManager.SaveSell(stockOutItem) && itemManager.UpdateAvailableQuantityByItemIdAndCompanyOfStockOut(stockOutItem))
                    {
                        count++;
                    }
                }

                if (count == listStockOut.Count)
                {
                    outputLabel.Text = "Sold Successfully";

                    addItemGridView.DataSource = null;
                    addItemGridView.DataBind();

                    ViewState["StockOutListVS"] = null;


                    companySelectionErrorLabel.Text = "";
                    itemSelectionErrorLabel.Text = "";
                    stockEmptyErrorLabel.Text = "";
                }
            }
        }

        // for damage added item
        protected void damageButton_Click(object sender, EventArgs e)
        {
            // get added items list from viewState
            List<StockOut> listStockOut = (List<StockOut>)ViewState["StockOutListVS"];
            int count = 0;

            if (listStockOut == null)
            {
                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "Add at least one element";
            }
            else
            {
                foreach (StockOut stockOutItem in listStockOut)
                {
                    if (stockOutManager.SaveDamage(stockOutItem) && itemManager.UpdateAvailableQuantityByItemIdAndCompanyOfStockOut(stockOutItem))
                    {
                        count++;
                    }
                }

                if (count == listStockOut.Count)
                {
                    outputLabel.Text = "Damage Items Stocked Out";

                    addItemGridView.DataSource = null;
                    addItemGridView.DataBind();

                    ViewState["StockOutListVS"] = null;


                    companySelectionErrorLabel.Text = "";
                    itemSelectionErrorLabel.Text = "";
                    stockEmptyErrorLabel.Text = "";
                }
            }
        }

        // for lost added item
        protected void lostButton_Click(object sender, EventArgs e)
        {
            // get added items list from viewState
            List<StockOut> listStockOut = (List<StockOut>)ViewState["StockOutListVS"];
            int count = 0;

            if (listStockOut == null)
            {
                companySelectionErrorLabel.Text = "";
                itemSelectionErrorLabel.Text = "";
                stockEmptyErrorLabel.Text = "";
                outputLabel.Text = "Add at least one element";
            }
            else
            {
                foreach (StockOut stockOutItem in listStockOut)
                {
                    if (stockOutManager.SaveLost(stockOutItem) && itemManager.UpdateAvailableQuantityByItemIdAndCompanyOfStockOut(stockOutItem))
                    {
                        count++;
                    }
                }

                if (count == listStockOut.Count)
                {
                    outputLabel.Text = "Lost Items Stocked Out";

                    addItemGridView.DataSource = null;
                    addItemGridView.DataBind();

                    ViewState["StockOutListVS"] = null;


                    companySelectionErrorLabel.Text = "";
                    itemSelectionErrorLabel.Text = "";
                    stockEmptyErrorLabel.Text = "";
                }
            }
        }
    }
}
