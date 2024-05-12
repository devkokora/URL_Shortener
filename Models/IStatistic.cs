namespace URL_Shortener.Models
{
    public interface IStatistic
    {
        int Remening { get; set; }
        int UrlAlive { get; set; }
        void SetStatistic(int remening, int urlAlive);
    }
}
