using System.ComponentModel.DataAnnotations;
using UrlShortener.Utility.CustomValidation;

namespace UrlShortener.Models
{
    public class RegisterViewModel
    {
        public User User { get; set; }
        [ComparePassword]
        [RegularExpression(@"^(?!.*\s).*$", ErrorMessage = "Password cannot contains backspaces!")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string ConfirmPassword { get; set; }
    }
}
