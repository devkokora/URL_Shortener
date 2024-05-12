namespace URL_Shortener.Models.Interactives
{
    public interface IStatistic
    {
        int Remening { get; set; }
        int UrlAlive { get; set; }
        void SetStatistic(int remening, int urlAlive);
    }
}
