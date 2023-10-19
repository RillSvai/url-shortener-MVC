using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public T Get(Expression<Func<T, bool>>? filter, string? includeProperties);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter,string? includeProperties);
        public void Insert(T entity);
        public void InsertRange(IEnumerable<T> entities);
        public void Remove (T entity);
        public void RemoveRange(IEnumerable<T> entities);

    }
}
