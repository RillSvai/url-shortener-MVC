using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IUrlRepository UrlRepo { get; }
        public IUserRepository UserRepo { get; }

        public void Save();
    }
}
