using Microsoft.AspNetCore.SpaServices.AngularCli;
using ServerApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDistributedSqlServerCache(options => {
    options.ConnectionString = connectionString;
    options.SchemaName = "dbo";
    options.TableName = "SessionData";
});

builder.Services.AddSession(options => {
    options.Cookie.Name = "SoundSked.Session";
    options.IdleTimeout = System.TimeSpan.FromHours(48);
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.UseSpa(spa => spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"));

app.Run();
