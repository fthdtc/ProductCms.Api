using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Data.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int MinStockQuantity { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
