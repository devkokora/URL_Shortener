using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using System;

namespace URL_Shortener.Models.Interactives
{
    public class UrlInteractive : IUrlInteractive
    {
        UrlShortenerDbContext _urlShortenerDbContext;

        public UrlInteractive(UrlShortenerDbContext urlShortenerDbContext)
        {
            _urlShortenerDbContext = urlShortenerDbContext;
        }

        public string? GetLongUrl(string url)
        {
            var existingUrl = _urlShortenerDbContext.Urls.FirstOrDefault(u => u.ShortUrl == url);
            if (existingUrl is not null)
            {
                existingUrl.VisitorCount++;
                _urlShortenerDbContext.SaveChanges();
                return existingUrl.LongUrl;
            }
            return null;
        }

        public string Create(Url newUrl)
        {
            newUrl.ShortUrl = GenerateShortUrl(newUrl.LongUrl);
            if (!IsDuplicateZipLink(newUrl))
            {
                _urlShortenerDbContext.Urls.Add(newUrl);
                _urlShortenerDbContext.SaveChanges();
                if (newUrl.User is not null)
                {
                    newUrl.User.UrlsId ??= [];

                    newUrl.User.UrlsId.Add(newUrl.Id);
                }
                _urlShortenerDbContext.SaveChanges();
                return newUrl.ShortUrl;
            }
            return string.Empty;
        }

        private string GenerateShortUrl(string longUrl)
        {
            string variant = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            Random random = new();
            return new string(Enumerable.Range(0, 5).Select(c => variant[random.Next(variant.Length)]).ToArray());
        }

        public void Edit(Url url)
        {
            var existingUrl = _urlShortenerDbContext.Urls.Find(url.Id);
            if (existingUrl is not null && !IsDuplicateZipLink(url))
            {
                _urlShortenerDbContext.Entry(existingUrl).State = EntityState.Detached;
                _urlShortenerDbContext.Update(url);
                _urlShortenerDbContext.SaveChanges();
            }
        }

        private bool IsDuplicateZipLink(Url url)
        {
            var searchUrls = _urlShortenerDbContext.Urls.Where(u => u.ShortUrl == url.ShortUrl).ToList();

            if (searchUrls.Count == 0 || searchUrls.All(su => su.Id == url.Id))
                return false;
            else
                return true;
        }

        public void Delete(int id)
        {
            var existingUrl = _urlShortenerDbContext.Urls.Find(id);
            if (existingUrl is not null)
            {
                _urlShortenerDbContext.Urls.Remove(existingUrl);
                _urlShortenerDbContext.SaveChanges();
            }
        }

        public void DeleteAll(List<Url> urls)
        {
            if (urls is not null)
            {
                _urlShortenerDbContext.Urls.RemoveRange(urls);
                _urlShortenerDbContext.SaveChanges();
            }
        }

        public List<Url>? GetAll() => _urlShortenerDbContext.Urls.ToList();

        //public List<Url>? GetAllNonUser()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Url>? GetAllNonSubscription()
        //{
        //    throw new NotImplementedException();
        //}

        //public Url? GetUrlByZipLink(string? zipLink)
        //{
        //    return _urlShortenerDbContext.Urls.FirstOrDefault(u => u.ShortUrl == zipLink);
        //}
    }
}
