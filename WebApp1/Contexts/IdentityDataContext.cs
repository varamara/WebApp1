using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models.Entities;
using WebApp1.Models.Identity;

namespace WebApp1.Contexts;

public class IdentityDataContext : IdentityDbContext<AppUser>
{
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
    {

    }

    public DbSet<AddressEntity> AspNetAddresses { get; set; }
    public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductTagEntity> ProductTags { get; set; }
    public DbSet<ContactFormEntity> ContactForms { get; set; }

}
