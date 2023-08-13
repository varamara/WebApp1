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
    public DbSet<ContactFormEntity> ContactForms { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfigurera dina entiteter här

        modelBuilder.Entity<ProductCategoryEntity>().HasData(
            new ProductCategoryEntity { Id = 1, CategoryName = "new" },
            new ProductCategoryEntity { Id = 2, CategoryName = "popular" },
            new ProductCategoryEntity { Id = 3, CategoryName = "featured" }
        );

        modelBuilder.Entity<ProductEntity>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<ProductEntity>()
            .Property(p => p.ProductName)
            .IsRequired();

        // ... andra konfigurationer för ProductEntity

        modelBuilder.Entity<ProductCategoryEntity>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<ProductCategoryEntity>()
            .Property(c => c.CategoryName)
            .IsRequired();

        // Konfigurera relationen mellan ProductEntity och ProductCategoryEntity
        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.ProductCategory)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.ProductCategoryId)
            .OnDelete(DeleteBehavior.Restrict); // eller .Cascade om du vill att en kategori raderas om produkten raderas

        // ... andra konfigurationer för ProductCategoryEntity

        base.OnModelCreating(modelBuilder);
    }
}

