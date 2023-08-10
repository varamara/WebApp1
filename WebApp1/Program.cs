using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp1.Contexts;
using WebApp1.Models.Identity;
using WebApp1.Repositories;
using WebApp1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// contexts

builder.Services.AddDbContext<IdentityDataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
//builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

// repositories

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<ContactFormRepository>();
builder.Services.AddScoped<ProductCategoryRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductTagRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<UserAddressRepository>();


// services
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<DiscoverService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<UserAdminService>();
//builder.Services.AddScoped<UserService>();


builder.Services.AddScoped<CustomClaimsPrincipalFactory>();

builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;

})
    .AddEntityFrameworkStores<IdentityDataContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});

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