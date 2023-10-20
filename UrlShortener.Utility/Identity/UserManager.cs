using UrlShortener.DataAccess.Data;
using UrlShortener.Models;

namespace UrlShortener.Utility.Identity
{
    public class UserManager : IUserManager<User>
    {
        private readonly ApplicationDbContext _db;
        public UserManager( ApplicationDbContext db)
        {
            _db = db;
        }

        public void AppointRole(User user)
        {
            if (_db.AdminEmails.Any(obj => obj.Email == user.Email)) 
            {
                user.Role = SD.Role_Admin;
                return;
            }
            user.Role = SD.Role_Customer;
        }

        public bool IsInRole(User user, string role)
        {
            if (user == null) return false;
            if (user.Role == role) return true;
            return false;
        }
        public bool IsSignedIn(User user) 
        {
            if (user == null) return false;
            return true;
        }
    }
}
