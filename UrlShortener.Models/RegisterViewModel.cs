

namespace UrlShortener.Models
{
    public class RegisterViewModel
    {
        public User User { get; set; }
        [ComparePasswordAttribute("User")]
        public string ConfirmPassword { get; set; }
    }
}
