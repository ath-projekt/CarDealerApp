using CarDealer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Database
{
    //public class DatabaseContext : DbContext
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            DBInitializer.Seed(this);
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<User> Users { get; set; }

    }
}