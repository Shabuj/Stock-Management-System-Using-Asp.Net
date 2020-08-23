using StockMS.DAL;
using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMS.BLL
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway = new CategoryGateway();
        public string Save(Category category)
        {
            if (categoryGateway.IsCategoryNameExists(category.CategoryName))
            {
                return "Category Name already exists";
            }
            else
            {
                int rowEffected= categoryGateway.SaveCategory(category);
                if(rowEffected>0)
                {
                    return "Successfully Inserted ";
                }
                else
                {
                    return " Insert failed ! ";
                }
            }
            
        }

      public List<Category> GetAllCategory()
        {


            return categoryGateway.GetAllCategory();
        }
        public string UpdateCategoryNameById(Category category)
        {
            //first check categoryName alreary exists or not
            if (categoryGateway.IsCategoryNameExists(category.CategoryName))
            {
                return "Category Name already exists";
            }
            else
            {
                // update category
                int rowAffected = categoryGateway.UpdateCategoryNameById(category);

                if (rowAffected > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
        }
    }
}