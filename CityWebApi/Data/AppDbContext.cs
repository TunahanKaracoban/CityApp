using CityWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CityWebApi.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<City> Cities { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
