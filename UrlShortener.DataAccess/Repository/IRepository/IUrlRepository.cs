using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.DataAccess.Repository.IRepository
{
    public interface IUrlRepository : IRepository<Url>
    {
        public void Update(Url entity);
    }
}
