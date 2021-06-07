using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Data.Entity.ApiModels
{
    public class SearchRequest
    {
        public string QueryText { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
    }
}
