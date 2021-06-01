using ILenguage.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ILenguage.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Sday> Sdays{get;set;}
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionDetail> SessionsDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<UserSchedule> UserSchedules { get; set; }
        public DbSet<UserSubscription> UserSuscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RelatedUser> RelatedUsers { get; set; }
        public DbSet<LanguageOfInterest> LanguageOfInterests { get; set; }
        public DbSet<TopicsOfInterest> TopicsOfInterests { get; set; }
        public DbSet<UserLanguages> UserLanguages { get; set; }
        public DbSet<UserTopics> UserTopics { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //*Suscription
            modelBuilder.Entity<Subscription>().ToTable("Subscriptions");
            modelBuilder.Entity<Subscription>().HasKey(s => s.Id);
            modelBuilder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Subscription>().Property(s => s.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Subscription>().Property(s => s.MonthDuration).IsRequired();
            modelBuilder.Entity<Subscription>().Property(s => s.Price).IsRequired();

            //*UserSubscription
            modelBuilder.Entity<UserSubscription>().ToTable("UserSubscriptions");
            modelBuilder.Entity<UserSubscription>().HasKey(us => new { us.UserId, us.SubscriptionId, us.InitialDate });
            //relationship between user and subscription
            modelBuilder.Entity<UserSubscription>()
                .HasOne(us => us.User)
                .WithMany(us => us.UserSubscriptions)
                .HasForeignKey(us => us.UserId);
            modelBuilder.Entity<UserSubscription>()
                .HasOne(us => us.Subscription)
                .WithMany(us => us.UserSubscriptions)
                .HasForeignKey(us => us.SubscriptionId);



            //TopicsOfInterest
            modelBuilder.Entity<TopicsOfInterest>().ToTable("TopicsOfInterest");
            modelBuilder.Entity<TopicsOfInterest>().HasKey(t => t.Id);
            modelBuilder.Entity<TopicsOfInterest>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<TopicsOfInterest>().Property(t => t.Name).IsRequired();
            //UserTopics
            modelBuilder.Entity<UserTopics>().ToTable("UserTopics");
            modelBuilder.Entity<UserTopics>().HasKey(ut => new { ut.UserId, ut.TopicId });
            modelBuilder.Entity<UserTopics>()
                .HasOne(ut => ut.Topic)
                .WithMany(ut => ut.UserTopic)
                .HasForeignKey(ut => ut.TopicId);

            modelBuilder.Entity<UserTopics>()
                .HasOne(ut => ut.User)
                .WithMany(ut => ut.UserTopic)
                .HasForeignKey(ut => ut.UserId);

            //LanguageOfInterest
            modelBuilder.Entity<LanguageOfInterest>().ToTable("LanguageOfInterest");
            modelBuilder.Entity<LanguageOfInterest>().HasKey(l => l.Id);
            modelBuilder.Entity<LanguageOfInterest>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<LanguageOfInterest>().Property(l => l.Name).IsRequired();

            modelBuilder.Entity<UserLanguages>().ToTable("UserLanguages");
            modelBuilder.Entity<UserLanguages>().HasKey(ul => new { ul.UserId, ul.LanguageId });
            modelBuilder.Entity<UserLanguages>()
                .HasOne(ut => ut.LanguageOfInterest)
                .WithMany(ut => ut.UserLanguage)
                .HasForeignKey(ut => ut.LanguageId);

            modelBuilder.Entity<UserLanguages>()
                .HasOne(ut => ut.User)
                .WithMany(ut => ut.UserLanguage)
                .HasForeignKey(ut => ut.UserId);
            // User
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Description).IsRequired().HasMaxLength(245);
            // ROLE
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<Role>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(30);

            modelBuilder.Entity<Role>()
            .HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);

            // RelatedUser
            modelBuilder.Entity<RelatedUser>().ToTable("RelatedUser");
            modelBuilder.Entity<RelatedUser>().HasKey(p => new { p.UserIdOne, p.UserIdTwo });

            modelBuilder.Entity<RelatedUser>()
                .HasOne(ru => ru.UserOne)
                .WithMany(ru => ru.RelatedUsers)
                .HasForeignKey(ru => ru.UserIdOne);


            //*Schedule
            modelBuilder.Entity<Schedule>().ToTable("Schedules");
            modelBuilder.Entity<Schedule>().HasKey(s => s.Id);
            modelBuilder.Entity<Schedule>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
            // Constraints
            modelBuilder.Entity<Schedule>()
                .HasMany<Sday>(g => g.Sdays)
                .WithOne(s => s.CurrentSchedule)
                .HasForeignKey(s => s.CurrentScheduleId);

            //*UserSchedules
            modelBuilder.Entity<UserSchedule>().ToTable("UserSchedules");
            modelBuilder.Entity<UserSchedule>().HasKey(us => new { us.UserId, us.ScheduleId });
            //relationship between user and schedules
            modelBuilder.Entity<UserSchedule>()
                .HasOne(us => us.User)
                .WithMany(us => us.UserSchedules)
                .HasForeignKey(us => us.UserId);
            modelBuilder.Entity<UserSchedule>()
                .HasOne(us => us.Schedule)
                .WithMany(us => us.UserSchedules)
                .HasForeignKey(us => us.ScheduleId);

            // Day Entity
          /*   modelBuilder.Entity<Day>().ToTable("Days");
            modelBuilder.Entity<Day>().HasKey(p => p.Id);
            modelBuilder.Entity<Day>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            // Constraints
            modelBuilder.Entity<Day>()
                .HasMany(p => p.Sessions)
                .WithOne(p => p.Day)
                .HasForeignKey(p => p.DayId); */

            // Session Entity

            modelBuilder.Entity<Session>().ToTable("Sessions");

            // Constraints

            modelBuilder.Entity<Session>().HasKey(p => p.Id);
            modelBuilder.Entity<Session>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            modelBuilder.Entity<Session>().Property(p => p.StartAt).IsRequired();
            modelBuilder.Entity<Session>().Property(p => p.EndAt).IsRequired();
            modelBuilder.Entity<Session>().Property(p => p.Link).IsRequired().HasMaxLength(200);

            // Relationships

            modelBuilder.Entity<Session>()
                .HasOne(p => p.SessionDetail)
                .WithOne(p => p.Session)
                .HasForeignKey<SessionDetail>(p => p.SessionId);

            // SessionDetail Entity

            modelBuilder.Entity<SessionDetail>().ToTable("SessionDetails");

            // Constraints

            modelBuilder.Entity<SessionDetail>().HasKey(p => p.Id);
            modelBuilder.Entity<SessionDetail>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<SessionDetail>().Property(p => p.State).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<SessionDetail>().Property(p => p.Topic).IsRequired();
            modelBuilder.Entity<SessionDetail>().Property(p => p.Information).IsRequired();


            // Naming Conventions Policy

            //modelBuilder.ApplySnakeCaseNamingConvention();
        }
    }
}