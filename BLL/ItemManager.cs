using StockMS.DAL;
using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.BLL
{
    public class ItemManager
    {
        ItemGateway itemGateway;
        StockInGateway stockInGateway;

        public ItemManager()
        {
            itemGateway = new ItemGateway();
            stockInGateway = new StockInGateway();
        }

        // save item
        public string Save(Items item)
        {
            // check item already exists or not
            if (itemGateway.CheckItemExists(item))
            {
                return "Item already exists";
            }
            else
            {
                item.AvailableQuantity = 0;
                // save item
                int rowAffected = itemGateway.Save(item);

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

        // get item by company
        public List<Items> GetItemByCompany(int companyId)
        {
            return itemGateway.GetItemByCompany(companyId);
        }

        // get item details by item
        public Items GetItemByItemAndCompany(int companyId, int itemId)
        {
            return itemGateway.GetItemByItemAndCompany(companyId, itemId);
        }

        // update available quantity by stock in
        public string UpdateAvailableQuantityByItemIdAndCompany(StockIn stockIn, int totalQuantity)
        {
            // update available quantity item
            int rowAffected = itemGateway.UpdateAvailableQuantityByItemIdAndCompany(stockIn, totalQuantity);
            int rowAffectedOnStockInTable = stockInGateway.Save(stockIn);

            if (rowAffected > 0 && rowAffectedOnStockInTable > 0)
            {
                return "Stock In Successfull";
            }
            else
            {
                return "Stock In Failed";
            }
        }

        // get item and company name by itemId
        public TemporaryTable GetItemNameAndCompanyNameByItemId(int itemId)
        {
            return itemGateway.GetItemNameAndCompanyNameByItemId(itemId);
        }

        // update from item table available quantity
        public bool UpdateAvailableQuantityByItemIdAndCompanyOfStockOut(StockOut stockOut)
        {
            int quantity = itemGateway.GetAvailableQuantity(stockOut);

            int newQuantity = quantity - stockOut.StockOutQuantity;

            int rowsAffected = itemGateway.UpdateAvailableQuantityByItemIdAndCompanyOfStockOut(stockOut, newQuantity);

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // get all items
        public List<ItemViewModel> GetItem()
        {
            return itemGateway.GetItem();
        }

        // get total items
        public int GetTotalItems()
        {
            return itemGateway.GetTotalItems();
        }

        // get total stock in quantity from stockin gateway
        public int GetTotalStockInQuantity()
        {
            return stockInGateway.GetTotalStockInQuantity();
        }
    }
}