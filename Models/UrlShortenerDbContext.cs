using Microsoft.EntityFrameworkCore;

namespace URL_Shortener.Models
{
    public class UrlShortenerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Url> Urls { get; set; }

        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Urls)
                .WithOne(url => url.User)
                .HasForeignKey(url => url.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
