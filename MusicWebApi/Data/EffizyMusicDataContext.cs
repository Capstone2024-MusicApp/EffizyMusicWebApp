using Microsoft.EntityFrameworkCore;
using MusicWebApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MusicWebApi.Data
{
    public class EffizyMusicDataContext : DbContext
    {
        private readonly DbContextOptions _options;
        public EffizyMusicDataContext(DbContextOptions<EffizyMusicDataContext> options)
       : base(options)
        {
            _options = options;
        }
        //public DbSet<Lessons> Lessons { get; set; }

        public DbSet<Quiz> Quizes { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public virtual DbSet<Question> Questions { get; set; } = null!;

        public virtual DbSet<QuestionChoice> QuestionChoices { get; set; } = null!;

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
                    .HasForeignKey(d => d.ModuleId)
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
