using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Data.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int StockQuantity { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
