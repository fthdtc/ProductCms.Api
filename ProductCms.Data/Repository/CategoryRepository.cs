using ProductCms.Base.Interface;
using ProductCms.Data.Context;
using ProductCms.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductCms.Data.Repository
{
    public class CategoryRepository : IDbRepository<Category>
    {
        private EFCoreContext context = new EFCoreContext();

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}