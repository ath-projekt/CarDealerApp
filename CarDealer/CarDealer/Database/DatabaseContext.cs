using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            DBInitializer.Seed(this);
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
    }
}