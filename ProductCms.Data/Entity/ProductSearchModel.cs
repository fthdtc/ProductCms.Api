using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Data.Entity
{
    public class ProductSearchModel
    {
        public Product product { get; set; }
        public Category category { get; set; }
    }
}
