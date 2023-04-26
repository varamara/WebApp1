using Microsoft.EntityFrameworkCore;
using WebApp1.Contexts;
using WebApp1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));


builder.Services.AddScoped<ShowcaseService>(); //Instantierar new ShowcaseService()
builder.Services.AddScoped<DiscoverService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
