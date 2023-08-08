using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models.Entities;
using WebApp1.Models.Identity;

namespace WebApp1.Contexts;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {

    }

    public DbSet<AddressEntity> AspNetAddresses { get; set; }
    public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductTagEntity> ProductTags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TagEntity>().HasData(
            new TagEntity { Id = 1, TagName = "new" },
            new TagEntity { Id = 2, TagName = "Featured" },
            new TagEntity { Id = 3, TagName = "Popular" }
            );

            builder.Entity<ProductEntity>().HasData(
            new ProductEntity { Id = 1, Title = "Logitech MK549 Advanced", Price = 500, ImageUrl = "https://cf-images.dustin.eu/cdn-cgi/image/format=auto,quality=75,width=640,,fit=contain//image/d200001001725842/logitech-mk540-advanced-nordiska-l%C3%A4underna-sats-med-tangentbord-och-mus.jpg", Description = " blalala " }
             );

        builder.Entity<ProductTagEntity>().HasData(
            new ProductTagEntity { ProductId = 1, TagId = 1 }
            );

  
    }
}

