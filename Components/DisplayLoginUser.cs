using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;
using URL_Shortener.Services;

namespace URL_Shortener.Components
{
    public class DisplayLoginUser : ViewComponent
    {
        private readonly IUserService _userService;

        public DisplayLoginUser(IUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            if (_userService.User is not null)
            {
                return View(_userService.User);
            }
            return View(new User());
        }
    }
}
