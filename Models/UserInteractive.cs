
namespace URL_Shortener.Models
{
    public class UserInteractive : IUserInteractive
    {
        public User? User { get; set; }
        public List<Url>? Urls { get; set; }

        public void Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public List<Url> GetAllUrlsByUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
