
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data {
   
    public class CityDbContext : DbContext {
        public DbSet <City> Cities { get; set; }
        public CityDbContext(DbContextOptions<CityDbContext>options):base(options) {
       
        }
    }
}
