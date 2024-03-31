using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shofy.Discount.Entities;
using System.Data;

namespace Shofy.Discount.Context
{
    public class DapperContext : DbContext
    {
        readonly IConfiguration _configuration;
        readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-FCCIUDC;initial Catalog=ShofyDiscountDB;integrated Security=true;TrustServerCertificate=True");
        }
        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection => new SqlConnection(_connectionString);

    }
}
