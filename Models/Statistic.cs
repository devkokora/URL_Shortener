namespace URL_Shortener.Models
{
    public class Statistic : IStatistic
    {
        public int Remening {get; set; }
        public int UrlAlive { get; set; }
        public void SetStatistic(int remening, int urlAlive)
        {
            Remening = remening;
            UrlAlive = urlAlive;
        }
    }
}
