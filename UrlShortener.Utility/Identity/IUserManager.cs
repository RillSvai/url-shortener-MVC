using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Utility.Identity
{
    public interface IUserManager<T> where T : class
    {
        public bool IsInRole(T user, string role);
        public bool IsSignedIn(T user);
    }
}
