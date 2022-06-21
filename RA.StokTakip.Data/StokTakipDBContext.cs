using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RA.StokTakip.Entities.Model;

namespace RA.StokTakip.Data
{
    public class StokTakipDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        public DbSet<Employe> Employe { get; set; } 
    }
}
