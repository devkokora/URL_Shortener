using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;

namespace URL_Shortener.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlInteractive _urlInteractive;
        public UrlService(IUrlInteractive urlInteractive)
        {
            _urlInteractive = urlInteractive;
        }
        public void RemoveOutOfDatedUrls()
        {
            var urls = _urlInteractive.GetAll();
            var now = DateTime.UtcNow.AddHours(7);
            var outDatedUrls = new List<Url>();
            var expDate = DateTime.UtcNow.AddHours(7) - TimeSpan.FromDays(30);
            if (urls is not null)
            {
                foreach (var url in urls)
                {
                    if (url.Create_at < expDate ||
                        (url.User is not null &&
                        url.User.Subscription_End < now))
                    {
                        outDatedUrls.Add(url);
                    }
                }
            }
            _urlInteractive.DeleteAll(outDatedUrls);
        }
    }
}
