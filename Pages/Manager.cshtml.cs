using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;

namespace URL_Shortener.Pages
{
    public class ManagerModel : PageModel
    {
        private readonly IUrlInteractive _urlInteractive;
        private readonly IUserInteractive _userInteractive;
        public List<Url>? urls { get; set; } = new();
        [BindProperty]
        public Url? edirUrl { get; set; }

        public ManagerModel(IUrlInteractive urlInteractive, IUserInteractive userInteractive, IHttpContextAccessor httpContextAccessor)
        {
            _urlInteractive = urlInteractive;
            _userInteractive = userInteractive;

            var userId = httpContextAccessor?.HttpContext?.Session.GetInt32("UserId");
            var user = _userInteractive.GetUserById(userId);
            if (user is not null)
            {
                _userInteractive.User = user;
            }
        }

        public void OnGet()
        {
            var user = _userInteractive.User;
            if (user is not null)
            {
                urls = _userInteractive.GetAllUrlsByUser(user.Id);
            }
        }
    }
}
