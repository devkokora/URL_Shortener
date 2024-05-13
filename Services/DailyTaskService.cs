using Microsoft.AspNetCore.Components.Forms;
using URL_Shortener.Models.Interactives;

namespace URL_Shortener.Services
{
    public class DailyTaskService : IHostedService, IDisposable
    {
        private Timer? _timer;
        private readonly IServiceProvider _serviceProvider;

        public DailyTaskService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }        

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var nextTime = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, DateTimeKind.Utc).AddDays(1).AddHours(7);

            var dueTime = nextTime - now;
            //if (dueTime < TimeSpan.Zero)
            //{
            //    dueTime += TimeSpan.FromDays(1);
            //}

            _timer = new Timer(RemoveOutOfDatedUrls, null, dueTime, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private void RemoveOutOfDatedUrls(object? state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _urlService = scope.ServiceProvider.GetRequiredService<IUrlService>();
                _urlService.RemoveOutOfDatedUrls();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
