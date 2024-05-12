using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URL_Shortener.Models;

namespace URL_Shortener.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Url { get; set; }
        private readonly IUrlInteractive _urlInteractive;

        public IndexModel(IUrlInteractive urlInteractive)
        {
            _urlInteractive = urlInteractive;
        }
        public IActionResult OnGet(string? url)
        {
            if (!string.IsNullOrEmpty(url) && url.Length == 5)
            {
                return Redirect("https://www.google.com");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(Url))
            {

                if (Url.Length > 5)
                {
                    _urlInteractive.Create(Url);
                }
                else
                {
                    var existingUrl = _urlInteractive.GetLongUrl(Url);
                    return Redirect(existingUrl);
                }
            }
            return Page();
        }
    }
}
