using Microsoft.EntityFrameworkCore;
using TransporteArequipaAPI.Models;

namespace TransporteArequipaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}

