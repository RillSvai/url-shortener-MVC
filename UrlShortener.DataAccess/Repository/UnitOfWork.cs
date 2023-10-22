using UrlShortener.DataAccess.Data;
using UrlShortener.DataAccess.Repository.IRepository;
using UrlShortener.Models;
using UrlShortener.Utility.Identity;

namespace UrlShortener.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IUrlRepository UrlRepo { get; private set; }

        public IUserRepository UserRepo {get; private set;}

        public UnitOfWork(ApplicationDbContext db, IUserManager<User> userManager)
        {
            _db = db;
            UrlRepo = new UrlRepository(db);
            UserRepo = new UserRepository(db, userManager );
        }
        async public Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
