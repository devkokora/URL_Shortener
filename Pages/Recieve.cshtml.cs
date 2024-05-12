using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace URL_Shortener.Pages
{
    public class RecieveModel : PageModel
    {
        public string? shortUrl;
        public string? longUrl;
        public RecieveModel(IHttpContextAccessor httpContextAccessor)
        {
            var recieveUrl = httpContextAccessor?.HttpContext?.Session.GetString("ShortUrlOutput");
            var fullUrl = httpContextAccessor?.HttpContext?.Session.GetString("LongUrlOutput");
            if (recieveUrl is not null && fullUrl is not null)
            {
                shortUrl = recieveUrl;
                longUrl = fullUrl;
            }
        }
        public void OnGet()
        {
        }
    }
}
