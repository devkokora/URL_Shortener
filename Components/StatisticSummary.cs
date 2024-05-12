using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Diagnostics.Metrics;
using URL_Shortener.Models;

namespace URL_Shortener.Components
{
    public class StatisticSummary : ViewComponent
    {
        private int Remening = 916_132_832;
        private readonly UrlShortenerDbContext _urlShortenerDbContext;
        public StatisticSummary(UrlShortenerDbContext urlShortenerDbContext)
        {
            _urlShortenerDbContext = urlShortenerDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var statistic = new Statistic();
            var countUrl = _urlShortenerDbContext.Urls.Count();

            statistic.SetStatistic(Remening - countUrl, countUrl);

            return View(statistic);
        }
    }
}
