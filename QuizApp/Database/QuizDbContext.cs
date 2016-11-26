using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuizApp.Database.Model;

namespace QuizApp.Database
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext() : base() { }

        public QuizDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
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
                .WithMany(xz => xz.Events)
                .HasForeignKey(x => x.TeamId);

            modelBuilder.Entity<TeamEvent>()
                .HasOne(x => x.Event)
                .WithMany(xz => xz.TeamEvent)
                .HasForeignKey(x => x.EventId);

            modelBuilder.Entity<TeamUser>().HasKey(x => new { x.TeamId, x.UserId });

            modelBuilder.Entity<TeamUser>()
                .HasOne(x => x.Team)
                .WithMany(xz => xz.TeamMembers)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamUser>()
                .HasOne(x => x.User)
                .WithMany(xz => xz.Teams)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
