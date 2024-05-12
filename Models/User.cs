using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URL_Shortener.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 6)]
        [Required]
        public string Username { get; set; } = string.Empty;
        [StringLength(64, MinimumLength = 8)]
        [Required]
        public string Password { get; set; } = string.Empty;
        [ValidateNever]
        public RoleType Role { get; set; } = RoleType.user;
        [ValidateNever]
        public DateTime Create_At { get; set; }
        public DateTime? Subscription_Start { get; set; }
        public DateTime? Subscription_End { get; set; }
        public List<int>? UrlsId { get; set; }
        public List<Url>? Urls { get; set; }
    }
}
