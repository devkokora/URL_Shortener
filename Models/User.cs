using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URL_Shortener.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Username must be lower than 50 charactor")]
        public string? Username { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Password must be lower than 50 charactor")]
        public string? Password { get; set; }
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
