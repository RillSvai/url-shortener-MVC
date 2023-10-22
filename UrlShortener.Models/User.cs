using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^(?!.*\s).*$", ErrorMessage = "Password cannot contains backspaces!" )]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string? Password { get; set; }
        [ValidateNever]
        public string? Role { get; set; }
        [ValidateNever]
        public List<Url>? CreatedUrls { get; set; }

    }
}
