using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApp1.Models.Entities;

namespace WebApp1.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
    }
}
