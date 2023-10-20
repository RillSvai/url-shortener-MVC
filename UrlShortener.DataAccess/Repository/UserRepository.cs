using UrlShortener.DataAccess.Data;
using UrlShortener.DataAccess.Repository.IRepository;
using UrlShortener.Models;
using UrlShortener.Utility;
using UrlShortener.Utility.Identity;

namespace UrlShortener.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IUserManager<User> _userManager; 
        public UserRepository(ApplicationDbContext db, IUserManager<User> userManager) : base(db)
        {
            _db = db;
            _userManager = userManager;
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
        }
        public override void Insert(User entity)
        {
            base.Insert(entity);
            _userManager.AppointRole(entity);
            SD.User = entity;
        }
    }
}
