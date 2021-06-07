using ProductCms.Base.Interface;
using ProductCms.Data.Entity;
using ProductCms.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Service.Services
{
    public class ProductSearchService : ISearchService<ProductSearchModel>
    { 
        private ProductSearchRepository ProductSearchRepository = new ProductSearchRepository();

        public List<ProductSearchModel> Search(string queryText, int minQuantity, int maxQuantity)
        {
            return ProductSearchRepository.SearchProduct(queryText, minQuantity, maxQuantity);
        } 
    }
}
