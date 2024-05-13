using Microsoft.EntityFrameworkCore;
using URL_Shortener.Middleware;
using URL_Shortener.Models;
using URL_Shortener.Models.Interactives;
using URL_Shortener.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHostedService, DailyTaskService>();

builder.Services.AddScoped<IUrlInteractive, UrlInteractive>();
builder.Services.AddScoped<IUserInteractive, UserInteractive>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUrlService, UrlService>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddControllersWithViews();
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
app.UseSession();
app.UseRouting();
//app.UseAuthentication();

//app.UseUserMiddleware();
app.UseMiddleware<UserMiddleware>();

app.MapRazorPages();
//app.MapDefaultControllerRoute();

app.Run();
