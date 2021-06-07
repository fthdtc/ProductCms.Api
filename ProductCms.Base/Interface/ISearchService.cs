using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Base.Interface
{
    public interface ISearchService<T>
    {
        List<T> Search(string queryText,int minQuantity,int maxQuantity);
    }
}
