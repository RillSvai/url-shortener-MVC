using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Url> CreatedUrls { get; set; }

    }
}
