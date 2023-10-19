using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DataAccess.Data;
using UrlShortener.DataAccess.Repository.IRepository;
using UrlShortener.Models;

namespace UrlShortener.DataAccess.Repository
{
    public class UrlRepository : Repository<Url>, IUrlRepository
    {
        private readonly ApplicationDbContext _db;
        public UrlRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void Update(Url entity)
        {
            _db.Urls.Update(entity);
        }
    }
}
