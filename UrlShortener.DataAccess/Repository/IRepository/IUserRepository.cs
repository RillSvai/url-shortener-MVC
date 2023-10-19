
using UrlShortener.Models;

namespace UrlShortener.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        public void Update(User user);
    }
}
