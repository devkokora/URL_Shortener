using Microsoft.AspNetCore.Components.Forms;
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
        private readonly IUrlInteractive _urlInteractive;
        public readonly IUserService _userService;
        public List<Url>? urls { get; set; }
        [BindProperty]
        public Url existingUrl { get; set; } = new();

        public ManagerModel(IUserInteractive userInteractive, IUrlInteractive urlInteractive, IUserService userService)
        {
            _userInteractive = userInteractive;
            _urlInteractive = urlInteractive;
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

        public IActionResult OnPost(string action)
        {
            if (ModelState.IsValid)
            {
                if (action == "remove")
                    _urlInteractive.Delete(existingUrl.Id);
                else
                    _urlInteractive.Edit(existingUrl);
            }
            return RedirectToPage();
        }
    }
}
