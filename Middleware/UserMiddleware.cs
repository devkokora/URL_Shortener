using URL_Shortener.Models.Interactives;
using URL_Shortener.Services;

namespace URL_Shortener.Middleware
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;

        public UserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserService _userService)
        {
            var userId = context.Session.GetInt32("userId");
            if (userId.HasValue)
            {
                var user = _userService.GetUserById((int)userId);
                if (user is not null)
                {
                    _userService.User = user;
                }
            }
            await _next(context);
        }
    }

    //Can directly say app.UseMiddleware<UserMiddleware>(); for all
    //but if need for some reasonable app.UseUserMiddleware(); need to build-in Extension on their class
    //public static class UserMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseUserMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<UserMiddleware>();
    //    }
    //}
}
