using ProductCms.Base.Interface;
using ProductCms.Data.Context;
using ProductCms.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductCms.Data.Repository
{
    public class ProductRepository : IDbRepository<Product>
    {
        private EFCoreContext context = new EFCoreContext();

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
