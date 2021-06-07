using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCms.Base.Interface;
using ProductCms.Data.Entity;
using ProductCms.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.UnitTest
{
    [TestClass]
    public class ProductSearchTest
    {
        [TestMethod]
        public void SearchTest()
        {

            ISearchService<ProductSearchModel> searchService = new ProductSearchService();

            //search missing quantity product
            var results = searchService.Search("Samsung Galaxy A51", 0,0);

            if (results.Count > 0)
            {
                Assert.Fail("Samsung Galaxy A51 is missing quantity");
            }

            var resultJ5 = searchService.Search("J5", 50, 200);

            if (resultJ5.Count == 0)
            {
                Assert.Fail("J5 not found");
            }
        }
    }
}
 