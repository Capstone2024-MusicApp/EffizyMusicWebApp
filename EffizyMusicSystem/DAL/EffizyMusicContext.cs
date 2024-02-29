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
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<Module> Modules { get; set; }        
        //public DbSet<Lesson> Lessons { get; set; }
        //public DbSet<Instructor> Instructors { get; set; }
        //public DbSet<Instrument> Instruments { get; set; }
    }

}
