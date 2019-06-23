using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options): base(options)
        {
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
    }
}