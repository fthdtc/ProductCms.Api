using ProductCms.Base.Interface;
using ProductCms.Data.Context;
using ProductCms.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ProductCms.Base.Helper;

namespace ProductCms.Data.Repository
{
    public class ProductSearchRepository : IDbRepository<ProductSearchModel>
    {

        public List<ProductSearchModel> SearchProduct(string queryText, int minQuantity, int maxQuantity)
        {
            try
            {
                using (EFCoreContext context = new EFCoreContext())
                {
                    var result = (from products in context.Products.ToList()
                                  join categories in context.Categories.ToList()
                                  on products.CategoryId equals categories.Id
                                  where
                                  (
                                    (products.Title.ToLowerInvariant().Contains(queryText.ToLowerInvariant())) ||
                                    (products.Description != null && products.Description.ToLowerInvariant().Contains(queryText.ToLowerInvariant())) ||
                                    (categories.CategoryName.ToLowerInvariant().Contains(queryText.ToLowerInvariant())) ||
                                    (categories.CategoryDescription != null && categories.CategoryDescription.ToLowerInvariant().Contains(queryText.ToLowerInvariant()))
                                  )
                                  && products.StockQuantity >= categories.MinStockQuantity
                                  && (minQuantity == 0 || products.StockQuantity >= minQuantity)
                                  && (maxQuantity == 0 || products.StockQuantity < maxQuantity)

                                  select new ProductSearchModel
                                  {
                                      category = new Category
                                      {
                                          Id = categories.Id,
                                          CategoryDescription = categories.CategoryDescription,
                                          CategoryName = categories.CategoryName,
                                          MinStockQuantity = categories.MinStockQuantity,
                                          TimeStamp = categories.TimeStamp
                                      },
                                      product = new Product
                                      {
                                          Id = products.Id,
                                          Title = products.Title,
                                          CategoryId = products.CategoryId,
                                          Description = products.Description,
                                          StockQuantity = products.StockQuantity,
                                          TimeStamp = products.TimeStamp
                                      }
                                  });

                    return result.ToList();
                } 
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format("Error occoured while searching product in ProductSearchRepository.SearchProduct : {0}", ex.Message);
                LogHelper.Exception(ex, errorMessage);

                throw;
            }
        }

        public void Delete(ProductSearchModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductSearchModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductSearchModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductSearchModel entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(ProductSearchModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductSearchModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
