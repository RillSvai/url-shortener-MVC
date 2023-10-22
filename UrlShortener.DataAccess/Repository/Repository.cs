using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DataAccess.Data;
using UrlShortener.DataAccess.Repository.IRepository;

namespace UrlShortener.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        async public virtual Task<T?> Get(Expression<Func<T, bool>>? filter, string? includeProperties)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(includeProperties)) 
            {
                foreach(var item in includeProperties.Split(new char[','], StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(item);
                }
            }
            if (filter != null) 
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        async public virtual Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var item in includeProperties.Split(new char[','], StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            if (filter != null) 
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        async public virtual Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        async public virtual Task InsertRange(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual void Remove(T entity)
        {
            if (entity is null) return; 
            _dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            if (entities is null) return;
            _dbSet.RemoveRange(entities);
        }
    }
}
