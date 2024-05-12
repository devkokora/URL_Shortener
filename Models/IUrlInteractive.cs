namespace URL_Shortener.Models
{
    public interface IUrlInteractive
    {
        string GetLongUrl(string url);
        string Create(string url);
        Url Edit(int id);
        void Delete(int id);
    }
}
