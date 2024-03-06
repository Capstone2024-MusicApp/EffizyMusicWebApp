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

        public EffizyMusicContext(DbContextOptions<EffizyMusicContext> options) : base(options)
        {
        }
        public DbSet<Lesson> Lessons { get; set; }
        //public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<InstructorRating> InstructorRatings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ViewLesson> ViewLessons { get; set; }
    }

}
