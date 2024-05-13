using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;
using URL_Shortener.Services;

namespace URL_Shortener.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUrlInteractive _urlInteractive;
        public readonly IUserService _userService;

        [BindProperty]
        public string? LongUrl { get; set; }
        private readonly string shortUrlPattern = "ziplink.to/";

        public IndexModel(
            IUrlInteractive urlInteractive,
            IUserInteractive userInteractive,
            IUserService userService)
        {
            _urlInteractive = urlInteractive;
            _userService = userService;
        }
        public IActionResult OnGet(string? url)
        {
            if (!string.IsNullOrEmpty(url) && url.Length == 5)
            {
                var tempUrl = _urlInteractive.GetLongUrl(url);
                if (!string.IsNullOrEmpty(tempUrl))
                {
                    return Redirect(tempUrl);
                }
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(LongUrl))
                return Page();

            var url = new Url();
            url.LongUrl = LongUrl;
            if (_userService.User is not null)
            {
                url.UserId = _userService.User.Id;
                url.User = _userService.User;
            }
            url.ShortUrl = _urlInteractive.Create(url);

            if (string.IsNullOrEmpty(url.ShortUrl))
            {
                HttpContext.Session.SetString("ShortUrlOutput", shortUrlPattern + url.ShortUrl);
                HttpContext.Session.SetString("LongUrlOutput", url.LongUrl);
                return RedirectToPage("Recieve");
            }
            return Page();
        }
    }
}
