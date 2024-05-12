namespace URL_Shortener.Models
{
    public interface IUserInteractive
    {
        User? User { get; set; }
        List<Url>? Urls { get; set; }
        void Create(User user);
        void Edit(User user);
        void Delete(int id);
        List<Url> GetAllUrlsByUser(int id);
    }
}
