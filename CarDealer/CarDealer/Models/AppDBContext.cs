using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class AppDBContext : IdentityDbContext<IdentityUser>
    {
        //public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        //{

        //}

        public DbSet<Car> Cars { get; set; }
        public DbSet<Opinion> Opinions { get; set; }


    }
}
