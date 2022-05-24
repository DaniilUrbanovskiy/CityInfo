using CityInfo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.DataAccess
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserCity> UserCity { get; set; }
    }
}
