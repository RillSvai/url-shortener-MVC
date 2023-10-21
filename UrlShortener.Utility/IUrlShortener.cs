using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Utility
{
    public interface IUrlShortener
    {
        public IEnumerable<char> GetTokenSymbols();
        public string GetToken(uint tokenLen = 1);
        public string GetShortUrl(string protocol, string host, string token);
    }
}
