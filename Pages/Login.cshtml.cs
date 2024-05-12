using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URL_Shortener.Models;

namespace URL_Shortener.Pages;

public class LoginModel : PageModel
{
    private readonly IUserInteractive _userInteractive;
    [BindProperty]
    public User? _user { get; set; }
    public LoginModel(IUserInteractive userInteractive)
    {
        _userInteractive = userInteractive;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("Manager");
    }
}
