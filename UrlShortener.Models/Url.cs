using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Models
{
    public class Url
    {
        [Key]
        public int Id { get; set; }
        public string? OriginalUrl { get; set; }
        public string? ShortUrl { get; set; }
        public string? TokenShortUrl { get; set; }
        public int? CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User User { get; set; }

    }
}
