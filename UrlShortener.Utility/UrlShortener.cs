using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Utility
{
    public class UrlShortener : IUrlShortener
    {
        public IEnumerable<char> GetTokenSymbols() 
        {
            return Enumerable.Range(48, 58-48).Select(i => (char)i).Concat(Enumerable.Range(65, 91-65).Select(i => (char)i)).Concat(Enumerable.Range(97, 123-97).Select(i => (char)i));
        }
        public string GetToken(uint tokenLen = 1) 
        {
            if (tokenLen == 0) tokenLen++;
            List<char> symbols = GetTokenSymbols().ToList();
            Random rnd = new Random();
            return string.Concat(Enumerable.Range(0, (int)tokenLen).Select(_ => symbols[rnd.Next(0, symbols.Count)]));
        }
        public string GetShortUrl(string protocol, string host,string token) 
        {
            return $"{protocol}://{host}/redirector/{token}";
        }
    }
}
