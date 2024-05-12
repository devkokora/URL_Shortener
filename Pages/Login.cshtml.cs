using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URL_Shortener.Models.Interactives;

namespace URL_Shortener.Pages;

public class LoginModel : PageModel
{
    private readonly IUserInteractive _userInteractive;
    [BindProperty]
    public string? Email { get; set; }
    [BindProperty]
    public string? Password { get; set; }
    public LoginModel(IUserInteractive userInteractive)
    {
        _userInteractive = userInteractive;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
        {
            var user = _userInteractive.Login(Email, Password);
            if (user is not null)
            {
                return RedirectToPage("Manager");
            }
        }
        return Page();
    }
}
