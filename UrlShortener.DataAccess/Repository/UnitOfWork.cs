using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DataAccess.Data;
using UrlShortener.DataAccess.Repository.IRepository;

namespace UrlShortener.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IUrlRepository UrlRepo { get; private set; }

        public IUserRepository UserRepo {get; private set;}

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            UrlRepo = new UrlRepository(db);
            UserRepo = new UserRepository(db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
