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
        //public DbSet<Lessons> Lessons { get; set; }

        public DbSet<Quiz> Quizes { get; set; }
    }

}
