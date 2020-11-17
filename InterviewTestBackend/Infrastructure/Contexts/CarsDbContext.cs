using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Contexts
{
    public class CarsDbContext : DbContext
    {
        public DbSet<CarDetail> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=localhost;database=cars;trusted_connection=true;");
        }

        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {
            
        }
    }
}
