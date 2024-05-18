using Microsoft.EntityFrameworkCore;
using Shofy.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Cargo.DataAccessLayer.Context
{
    public class CargoDbContext : DbContext
    {
        public CargoDbContext(
                     DbContextOptions<CargoDbContext> options)
                     : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<CargoOperation> CargoOperations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Detail> Details { get; set; }
    }
}
