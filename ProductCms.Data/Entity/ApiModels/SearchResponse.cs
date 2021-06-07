using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Data.Entity.ApiModels
{
    public class SearchResponse
    {
        public List<ProductSearchModel> productList { get; set; }
    }
}
