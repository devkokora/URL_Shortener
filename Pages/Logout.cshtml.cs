using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URL_Shortener.Services;

namespace URL_Shortener.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            var userService = HttpContext.RequestServices.GetService<IUserService>();
            userService!.User = null;

            HttpContext.Session.Clear();
            return RedirectToPage("Login");
        }
    }
}
