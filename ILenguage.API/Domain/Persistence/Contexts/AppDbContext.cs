using ILenguage.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Suscription>Suscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Suscription>().ToTable("Suscription");
            modelBuilder.Entity<Suscription>().HasKey(s => s.Id);
            modelBuilder.Entity<Suscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Suscription>().Property(s => s.Name).IsRequired().HasMaxLength(20);
            


        }
    }
}