using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URL_Shortener.Middleware;
using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;
using URL_Shortener.Services;

namespace URL_Shortener.Pages;

public class LoginModel : PageModel
{
    private readonly IUserInteractive _userInteractive;
    private readonly IUserService _userService;
    [BindProperty]
    public new User User { get; set; } = new();

    public LoginModel(IUserInteractive userInteractive, IUserService userService)
    {
        _userInteractive = userInteractive;
        _userService = userService;
    }

    public void OnGet()
    {
        if (_userService.User is not null)
        {
            User = _userService.User;
        }
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            var user = _userInteractive.Login(User.Username, User.Password);
            if (user is not null)
            {
                HttpContext.Session.SetInt32("userId", user.Id);

                //var userService = HttpContext.RequestServices.GetService<IUserService>();
                var userMiddleware = new UserMiddleware(_ => Task.CompletedTask);

                if (_userService is not null)
                    userMiddleware.InvokeAsync(HttpContext, _userService).Wait();

                return RedirectToPage("Manager");
            }
        }
        return RedirectToPage("Register");
    }
}
