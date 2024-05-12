namespace URL_Shortener.Models.Interactives
{
    public interface IUserInteractive
    {
        User? User { get; set; }
        List<Url>? Urls { get; set; }
        void Create(User user);
        void ChangePassword(int id, string newPassword);
        //void ChangeEmail(int id, string newEmail);
        void Delete(int id);
        void Subscription(int id, int month);
        User? Login(string email, string password);
        List<Url>? GetAllUrlsByUser(int id);
        User? GetUserByEmail(string email);
        User? GetUserById(int? id);
    }
}
