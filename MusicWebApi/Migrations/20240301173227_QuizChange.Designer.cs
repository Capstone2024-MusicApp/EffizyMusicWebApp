﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicWebApi.Data;

#nullable disable

namespace MusicWebApi.Migrations
{
    [DbContext(typeof(EffizyMusicDataContext))]
    [Migration("20240301173227_QuizChange")]
    partial class QuizChange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicWebApi.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("MusicWebApi.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("MusicWebApi.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("MusicWebApi.Models.QuestionChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChoiceText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionChoices");
                });

            modelBuilder.Entity("MusicWebApi.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("QuizTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Quizes", (string)null);
                });

            modelBuilder.Entity("MusicWebApi.Models.Answer", b =>
                {
                    b.HasOne("MusicWebApi.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .IsRequired()
                        .HasConstraintName("FK_Answer_Question");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("MusicWebApi.Models.Question", b =>
                {
                    b.HasOne("MusicWebApi.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .IsRequired()
                        .HasConstraintName("FK_Question_Quiz");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("MusicWebApi.Models.QuestionChoice", b =>
                {
                    b.HasOne("MusicWebApi.Models.Question", "Question")
                        .WithMany("QuestionChoices")
                        .HasForeignKey("QuestionId")
                        .IsRequired()
                        .HasConstraintName("FK_QuestionChoices_Question");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("MusicWebApi.Models.Quiz", b =>
                {
                    b.HasOne("MusicWebApi.Models.Module", "Module")
                        .WithMany("Quizzes")
                        .HasForeignKey("ModuleId")
                        .IsRequired()
                        .HasConstraintName("FK_Module_Quiz");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("MusicWebApi.Models.Module", b =>
                {
                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("MusicWebApi.Models.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("QuestionChoices");
                });

            modelBuilder.Entity("MusicWebApi.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
