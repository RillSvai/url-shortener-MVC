
using UrlShortener.Models;

namespace UrlShortener.Utility.Identity
{
    public class UserManager : IUserManager<User>
    {

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
