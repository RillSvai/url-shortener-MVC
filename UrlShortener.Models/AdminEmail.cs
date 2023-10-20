using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Models
{
    public class AdminEmail
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
