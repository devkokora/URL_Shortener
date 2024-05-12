using URL_Shortener.Models;

namespace URL_Shortener.Services
{
    public interface IUserService
    {
        User? User { get; set; }
        User? GetUserById(int userId);
    }
}
