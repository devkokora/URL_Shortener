using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;

namespace URL_Shortener.Services
{
    public class UserService : IUserService
    {
        private readonly IUserInteractive _userInteractive;
        public User? User { get; set; }

        public UserService(IUserInteractive userInteractive)
        {
            _userInteractive = userInteractive;
        }       

        public User? GetUserById(int userId)
        {
            return _userInteractive.GetUserById(userId);
        }
    }
}
