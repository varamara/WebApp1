using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models.Entities;
using WebApp1.Models.Identity;

namespace WebApp1.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        public DbSet<AddressEntity> AspNetAddresses { get; set; }
        public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }
    }
} 
