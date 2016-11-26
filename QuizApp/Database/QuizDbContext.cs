using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuizApp.Database.Model;
using System.Linq;

namespace QuizApp.Database
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext() : base() { }

        public QuizDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-Q2LUF87\SQLEXPRESS;Initial Catalog=RSC2016Test;Integrated Security=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TeamEvent> TeamEvents { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamEvent>().HasKey(x => new {x.TeamId, x.EventId });

            modelBuilder.Entity<TeamEvent>()
                .HasOne(x => x.Team)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.TeamId)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<TeamEvent>()
                .HasOne(x => x.Event)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.EventId)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<TeamUser>().HasKey(x => new { x.TeamId, x.UserId });

            modelBuilder.Entity<TeamUser>()
                .HasOne(x => x.Team)
                .WithMany(x => x.Participants)
                .HasForeignKey(x => x.TeamId)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity< TeamUser>()
                .HasOne(x => x.User)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.UserId)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
