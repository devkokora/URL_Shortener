using Microsoft.EntityFrameworkCore;
using URL_Shortener.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUrlInteractive, UrlInteractive>();

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/index", "{*url}");
});

builder.Services.AddDbContext<UrlShortenerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UrlShortenerDbContextConnection"));
    options.EnableSensitiveDataLogging();
}
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

//app.UseRouting();
//app.UseAuthentication();

app.MapRazorPages();

app.Run();
