using ILenguage.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionDetails> SessionsDetails { get; set; }

        public DbSet<Suscription>Suscriptions { get; set; }

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
           /* modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod");
            modelBuilder.Entity<PaymentMethod>().HasKey(pm => pm.Id);
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.CardNumber).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.CvcCode).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.OwnerName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.Year).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.month).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.PaymentNetwork).IsRequired();*/
            
            //!UserSuscription
            modelBuilder.Entity<UserSuscription>().ToTable("UserSuscription");
            modelBuilder.Entity<UserSuscription>().HasKey(us => us.SuscriptionId);
            modelBuilder.Entity<UserSuscription>().Property(us => us.UserId).IsRequired();
           // modelBuilder.Entity<UserSuscription>().Property(us => us.PaymentMethod).IsRequired();
            modelBuilder.Entity<UserSuscription>().Property(us => us.InitialDate).IsRequired();
            //TODO: user
            //Relatiosns

            modelBuilder.Entity<UserSuscription>()
                .HasOne(us => us.Suscription)
                .WithMany(us => us.UserSuscriptions)
                .HasForeignKey(us => us.SuscriptionId);
            modelBuilder.Entity<UserSuscription>()
               .HasOne(us => us.User)
               .WithMany(u => u.UserSuscriptions)
               .HasForeignKey(us => us.UserId);
            //TODO: i'm wondering if this relation is ok 






            //!Session
            modelBuilder.Entity<Session>().ToTable("Session");
            modelBuilder.Entity<Session>().HasKey(p => p.Id);
            modelBuilder.Entity<Session>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Session>().Property(p => p.StartAt).IsRequired();
            modelBuilder.Entity<Session>().Property(p => p.EndAt).IsRequired();
            modelBuilder.Entity<Session>().Property(p => p.Link).IsRequired().HasMaxLength(100);
            /*
            modelBuilder.Entity<Session>()
            .HasOne(pt => pt.User)
            .WithMany(p => p.Sessions)
            .HasForeignKey(pt => pt.UserId);*/

            //!Session Details
            modelBuilder.Entity<SessionDetails>().ToTable("SessionDetail");
            modelBuilder.Entity<SessionDetails>().HasKey(p => p.Id);
            modelBuilder.Entity<SessionDetails>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<SessionDetails>().Property(p => p.State).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<SessionDetails>()
            .HasOne(pt => pt.Session)
            .WithMany(p => p.SessionsDetails)
            .HasForeignKey(pt => pt.SessionId);




        }
    }
}