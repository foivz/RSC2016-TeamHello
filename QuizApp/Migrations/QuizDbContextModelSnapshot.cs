using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuizApp.Database;

namespace QuizApp.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    partial class QuizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuizApp.Database.Model.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Input");

                    b.Property<bool>("IsCorrect");

                    b.Property<int>("QuestionId");

                    b.HasKey("ID");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuizApp.Database.Model.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsActive");

                    b.Property<int>("ModeratorId");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("ModeratorId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("QuizApp.Database.Model.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<string>("Text");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.HasIndex("EventId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizApp.Database.Model.Team", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CaptainId");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("QuizApp.Database.Model.TeamEvent", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("EventId");

                    b.Property<int>("ID");

                    b.HasKey("TeamId", "EventId");

                    b.HasIndex("EventId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamEvents");
                });

            modelBuilder.Entity("QuizApp.Database.Model.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Nick");

                    b.Property<string>("UID");

                    b.Property<string>("Vendor");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuizApp.Database.Model.UserAnswer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Input");

                    b.Property<bool>("IsCorrect");

                    b.Property<int?>("QuestionId");

                    b.Property<int?>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAnswers");
                });

            modelBuilder.Entity("QuizApp.Database.TeamUser", b =>
                {
                    b.Property<int?>("TeamId");

                    b.Property<int?>("UserId");

                    b.Property<int>("ID");

                    b.HasKey("TeamId", "UserId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("TeamUsers");
                });

            modelBuilder.Entity("QuizApp.Database.Model.Answer", b =>
                {
                    b.HasOne("QuizApp.Database.Model.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizApp.Database.Model.Event", b =>
                {
                    b.HasOne("QuizApp.Database.Model.User", "Moderator")
                        .WithMany("ModedEvents")
                        .HasForeignKey("ModeratorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizApp.Database.Model.Question", b =>
                {
                    b.HasOne("QuizApp.Database.Model.Event", "Event")
                        .WithMany("Questions")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizApp.Database.Model.TeamEvent", b =>
                {
                    b.HasOne("QuizApp.Database.Model.Event", "Event")
                        .WithMany("TeamEvent")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizApp.Database.Model.Team", "Team")
                        .WithMany("Events")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizApp.Database.Model.UserAnswer", b =>
                {
                    b.HasOne("QuizApp.Database.Model.Question", "Question")
                        .WithMany("UserAnswers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("QuizApp.Database.Model.User", "User")
                        .WithMany("UserAnswers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("QuizApp.Database.TeamUser", b =>
                {
                    b.HasOne("QuizApp.Database.Model.Team", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId");

                    b.HasOne("QuizApp.Database.Model.User", "User")
                        .WithMany("Teams")
                        .HasForeignKey("UserId");
                });
        }
    }
}
