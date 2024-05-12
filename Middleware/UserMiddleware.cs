namespace URL_Shortener.Middleware
{
    public class UserMiddleware
    {
        private readonly RequestDelegate _next;
        public UserMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InVoke(HttpContext context, IUserService userService)
        {
            var userId = context.Session.GetInt32("userId");
            if (userId.HasValue)
            {
                var user = userService.GetUserbyId(userId.Value);
                if (user is not null)
                {
                    userService.User = user;
                }
            }
            await _next(context);
        }
    }
}
