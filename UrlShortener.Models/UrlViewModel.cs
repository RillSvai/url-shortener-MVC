using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Models
{
    public class UrlViewModel
    {
        public Url Url { get; set; }
        [Required]
        [Range(1, 40 )]
        [Display(Name = "Length of token")]
        public uint TokenLen { get; set; }
    }
}
