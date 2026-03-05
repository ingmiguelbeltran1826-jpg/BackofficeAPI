
using Microsoft.EntityFrameworkCore;
using BackofficeAPI.Entities;

namespace BackofficeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Mensajero> Mensajero { get; set; }
    }
}
