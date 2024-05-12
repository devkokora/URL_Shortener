using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace URL_Shortener.Models.Interactives
{
    public class UserInteractive : IUserInteractive
    {
        private readonly UrlShortenerDbContext _urlShortenerDbContext;
        public User? User { get; set; }
        public List<Url>? Urls { get; set; }

        public UserInteractive(UrlShortenerDbContext urlShortenerDbContext)
        {
            _urlShortenerDbContext = urlShortenerDbContext;
        }

        public void Create(User user)
        {
            if (!_urlShortenerDbContext.Users.Any(u => u.Username == user.Username))
            {
                user.Create_At = DateTime.Now;
                user.Password = PasswordHasher.HashPassword(user.Password);
                _urlShortenerDbContext.Users.Add(user);
                _urlShortenerDbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = _urlShortenerDbContext.Users.Find(id);
            if (user is not null)
            {
                _urlShortenerDbContext.Users.Remove(user);
                _urlShortenerDbContext.SaveChanges();
            }
        }

        public void ChangePassword(int id, string newPassword)
        {
            var tempUser = _urlShortenerDbContext.Users.Find(id);
            if (tempUser is not null)
            {
                tempUser.Password = PasswordHasher.HashPassword(newPassword);
                _urlShortenerDbContext.SaveChanges();
            }
        }

        public void Subscription(int id, int month)
        {
            var tempUser = _urlShortenerDbContext.Users.Find(id);
            if (tempUser is not null)
            {
                if (tempUser.Subscription_End is null || tempUser.Subscription_End.Value < DateTime.Now)
                {
                    tempUser.Subscription_Start = DateTime.Now;
                    tempUser.Subscription_End = tempUser.Subscription_Start.Value.AddMonths(month);
                }
                else
                {
                    tempUser.Subscription_End = tempUser.Subscription_End.Value.AddMonths(month);
                }
                _urlShortenerDbContext.SaveChanges();
            }
        }

        public List<Url>? GetAllUrlsByUser(int id)
        {
            var user = _urlShortenerDbContext.Users.Find(id);
            if (user is not null && user.UrlsId is not null)
            {
                user.Urls = new();
                foreach (var urlId in user.UrlsId)
                {
                    var tempUrl = _urlShortenerDbContext.Urls.Find(urlId);
                    if (tempUrl is not null)
                    {
                        user.Urls.Add(tempUrl);
                    }
                }
                return user.Urls;
            }
            return null;
        }

        public User? Login(string username, string password)
        {
            var tempUser = _urlShortenerDbContext.Users.FirstOrDefault(u => u.Username == username);
            if (tempUser is not null && PasswordHasher.VerifyPassword(password, tempUser.Password))
            {
                return tempUser;
            }
            return null;
        }

        public User? GetUserByEmail(string email)
            => _urlShortenerDbContext.Users.FirstOrDefault(u => u.Username == email);

        public User? GetUserById(int? id)
            => _urlShortenerDbContext.Users.Find(id);
    }
}
