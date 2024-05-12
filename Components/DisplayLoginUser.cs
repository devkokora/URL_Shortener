using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;

namespace URL_Shortener.Components
{
    public class DisplayLoginUser : ViewComponent
    {
        private readonly IUserInteractive _userInteractive;

        public DisplayLoginUser(IUserInteractive userInteractive, IHttpContextAccessor httpContextAccessor)
        {
            _userInteractive = userInteractive;
            var userId = httpContextAccessor?.HttpContext?.Session.GetInt32("UserId");
            var user = _userInteractive.GetUserById(userId);
            if (user is not null)
            {
                _userInteractive.User = user;
            }
        }

        public IViewComponentResult Invoke()
        {
            var user = _userInteractive.User;
            if (user is not null)
            {
                return View(user);
            }
            return View(new User());
        }
    }
}
