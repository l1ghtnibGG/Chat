using ChatApp.Hubs;
using ChatApp.Models;
using ChatApp.Models.Data;
using ChatApp.Models.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ChatApp");
builder.Services.AddDbContext<ChatDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IChatRepository<User>, EfUserRepository>();
builder.Services.AddScoped<IChatRepository<Tag>, EfTagRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapHub<ChatHub>("/Chat");
});

SeedData.EnsureData(app);

app.Run();
