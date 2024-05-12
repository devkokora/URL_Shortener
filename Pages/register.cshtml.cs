using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;

namespace URL_Shortener.Pages
{
    public class registerModel : PageModel
    {
        private readonly IUserInteractive _userInteractive;
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        [BindProperty]
        public string? ComfirmPassword { get; set; }

        public registerModel(IUserInteractive userInteractive)
        {
            _userInteractive = userInteractive;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(Email) &&
                !string.IsNullOrEmpty(Password) &&
                !string.IsNullOrEmpty(ComfirmPassword) &&
                Password == ComfirmPassword)
            {
                User user = new()
                {
                    Username = Email,
                    Password = Password
                };
                _userInteractive.Create(user);
                return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
