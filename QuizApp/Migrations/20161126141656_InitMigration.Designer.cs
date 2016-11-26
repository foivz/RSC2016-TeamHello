﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using QuizApp.Database;

namespace QuizApp.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20161126141656_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuizApp.Database.Model.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Input");

                    b.Property<int>("QuestionId");

                    b.HasKey("ID");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuizApp.Database.Model.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int?>("EventID");

                    b.Property<int>("ModeratorId");

                    b.Property<string>("Nick");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

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

                    b.HasIndex("CaptainId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("QuizApp.Database.Model.TeamEvent", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("EventId");

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

                    b.Property<int>("QuestionId");

                    b.Property<int>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAnswers");
                });

            modelBuilder.Entity("QuizApp.Database.TeamUser", b =>
                {
                    b.Property<int>("TeamId");

                    b.Property<int>("UserId");

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
                    b.HasOne("QuizApp.Database.Model.Event")
                        .WithMany("ModEvents")
                        .HasForeignKey("EventID");

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

            modelBuilder.Entity("QuizApp.Database.Model.Team", b =>
                {
                    b.HasOne("QuizApp.Database.Model.User", "Captain")
                        .WithMany()
                        .HasForeignKey("CaptainId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizApp.Database.Model.TeamEvent", b =>
                {
                    b.HasOne("QuizApp.Database.Model.Event", "Event")
                        .WithMany("Teams")
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
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizApp.Database.Model.User", "User")
                        .WithMany("UserAnswers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizApp.Database.TeamUser", b =>
                {
                    b.HasOne("QuizApp.Database.Model.Team", "Team")
                        .WithMany("Participants")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizApp.Database.Model.User", "User")
                        .WithMany("Teams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
