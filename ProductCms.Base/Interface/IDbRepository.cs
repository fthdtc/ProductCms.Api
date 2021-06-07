using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCms.Base.Interface
{
    public interface IDbRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDelete(T entity);
    }
}
