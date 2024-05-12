using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;
using URL_Shortener.Services;

namespace URL_Shortener.Pages
{
    public class ManagerModel : PageModel
    {
        private readonly IUserInteractive _userInteractive;
        public readonly IUserService _userService;
        public List<Url>? urls { get; set; } = new();
        [BindProperty]
        public Url? edirUrl { get; set; }

        public ManagerModel(IUserInteractive userInteractive, IUserService userService)
        {
            _userInteractive = userInteractive;
            _userService = userService;
        }

        public void OnGet()
        {
            var user = _userService.User;
            if (user is not null)
            {
                urls = _userInteractive.GetAllUrlsByUser(user.Id)?.Distinct().ToList();
            }
        }
    }
}
