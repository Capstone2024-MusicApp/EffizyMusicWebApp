using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public interface IEffizyMusicApplicationService
    {
        List<Lesson> GetLessons();
    }
    public class EffizyMusicApplicationService : IEffizyMusicApplicationService
    {
        private readonly EffizyMusicContext _context;

        internal EffizyMusicApplicationService(EffizyMusicContext context)
        {
            _context = context;
        }
        public List<Lesson> GetLessons()
        {
            return _context.Lessons.ToList();
        }

        public List<Payment> GetPayments()
        {
            return _context.Payments.ToList();
        }

        //Add your methods here that directly connects to the dtabase
    }
}
