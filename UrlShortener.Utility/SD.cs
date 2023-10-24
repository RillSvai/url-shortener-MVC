using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Utility
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Customer = "Customer";
        public static HtmlString AboutText { get; set; } 
            = new HtmlString("<h4>1) I made simple client-side validation URL with 'Uri' and didn`t allow equal urls in my database.\n" +
			"<br/> 2) Generating short url (with random token with custom length that user chose) for example 'https://localhost:7050/Hv3S'" +
                "<br/> 3) Next i create RedirectorController that catch any token in url" +
                "<br/> 4) Finnaly we checking or our database contain that token" +
                "<br/> That`s all. We can improve short url if we set RedirectorController as default and our short url will be shorter (without word redirector)</h4>");
        public static User? User { get; set; }
    }
}