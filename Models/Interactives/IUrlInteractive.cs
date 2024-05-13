namespace URL_Shortener.Models.Interactives
{
    public interface IUrlInteractive
    {
        string? GetLongUrl(string url);
        string Create(Url newUrl);
        void Edit(Url url);
        void Delete(int id);
        void DeleteAll(List<Url> urls);
        List<Url>? GetAll();
        //List<Url>? GetAllNonUser();
        //List<Url>? GetAllNonSubscription();
    }
}
