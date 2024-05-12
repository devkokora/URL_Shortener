namespace URL_Shortener.Models.Interactives
{
    public interface IUrlInteractive
    {
        string? GetLongUrl(string url);
        string Create(Url newUrl);
        void Edit(Url url);
        void Delete(int id);
    }
}
