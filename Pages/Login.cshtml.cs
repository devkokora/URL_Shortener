using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;

namespace URL_Shortener.Pages;

public class LoginModel : PageModel
{
    private readonly IUserInteractive _userInteractive;
    [BindProperty]
    public new User User { get; set; } = new();
    
    public LoginModel(IUserInteractive userInteractive)
    {
        _userInteractive = userInteractive;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            var user = _userInteractive.Login(User.Username, User.Password);
            if (user is not null)
            {
                HttpContext.Session.SetInt32("UserId", User.Id);
                return RedirectToPage("Manager");
            }
        }
        return Page();
    }
}
