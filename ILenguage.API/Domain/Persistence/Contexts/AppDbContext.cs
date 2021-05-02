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
        public DbSet<PaymentMethod>PaymentMethods { get; set; }
        public DbSet<UserSuscription> UserSuscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //!Suscription
            modelBuilder.Entity<Suscription>().ToTable("Suscription");
            modelBuilder.Entity<Suscription>().HasKey(s => s.Id);
            modelBuilder.Entity<Suscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Suscription>().Property(s => s.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Suscription>().Property(s => s.MonthDuration).IsRequired();
            modelBuilder.Entity<Suscription>().Property(s => s.Price).IsRequired();
            
            //!PaymentMethod
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod");
            modelBuilder.Entity<PaymentMethod>().HasKey(pm => pm.CardNumber);
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.CardNumber).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.CvcCode).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.OwnerName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.Year).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.month).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.PaymentNetwork).IsRequired();
            
            //!UserSuscription
            modelBuilder.Entity<UserSuscription>().ToTable("UserSuscription");
            modelBuilder.Entity<UserSuscription>().HasKey(us => us.SuscriptionId);
            modelBuilder.Entity<UserSuscription>().Property(us => us.UserId).IsRequired();
            modelBuilder.Entity<UserSuscription>().Property(us => us.PaymentMethod).IsRequired();
            modelBuilder.Entity<UserSuscription>().Property(us => us.InitialDate).IsRequired();
            //TODO: user
            //Relatiosns
           /* modelBuilder.Entity<UserSuscription>()
                .HasOne(us => us.Suscription)
                .WithMany(us => us.UserSuscription)
                .HasForeignKey(us => us.SuscriptionId);
          modelBuilder.Entity<UserSuscription>()
               .HasOne(us => us.User)
               .WithMany(u => u.UserSuscription)
               .HasForeignKey(us => us.UserId);*/
           
           








        }
    }
}