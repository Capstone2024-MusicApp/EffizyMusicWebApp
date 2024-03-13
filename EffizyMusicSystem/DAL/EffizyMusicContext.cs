using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.DAL
{
    public class EffizyMusicContext : DbContext
    {

        public EffizyMusicContext(DbContextOptions<EffizyMusicContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<InstructorRating> InstructorRatings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<ViewLesson> ViewLessons { get; set; }

        public DbSet<Quiz> Quizes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionChoice> QuestionChoices { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quizes");
                entity.Property(e => e.QuizTitle)
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.ModuleID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Module_Quiz");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Quiz");
            });

            modelBuilder.Entity<QuestionChoice>(entity =>
            {
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionChoices)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionChoices_Question");
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Question");
            });
        }
    }
}