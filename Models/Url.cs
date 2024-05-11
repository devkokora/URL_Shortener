using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URL_Shortener.Models
{
    public class Url
    {
        [Key]
        public int Id { get; set; }
        public string ShortUrl { get; set; } = string.Empty;
        [Required]
        public string LongUrl { get; set; } = string.Empty;
        public int VisitorCount { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
