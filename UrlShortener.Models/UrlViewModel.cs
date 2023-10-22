using System.ComponentModel.DataAnnotations;
using UrlAttribute = UrlShortener.Utility.CustomValidation.UrlAttribute;

namespace UrlShortener.Models
{
    public class UrlViewModel
    {
        [Url]
        public Url? Url { get; set; }

        [Required]
        [Range(1, 40 )]
        [Display(Name = "Length of token")]
        public uint TokenLen { get; set; }
    }
}
