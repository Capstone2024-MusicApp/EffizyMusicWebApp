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

        public  EffizyMusicApplicationService(EffizyMusicContext context)
        {
            _context = context;
        }
        public List<Lesson> GetLessons()
        {
            return _context.Lessons.ToList();
        }

        public  List<Feedback> GetFeedback()
        {
            return _context.Feedbacks.ToList();
        }

        public async Task<bool> InsertFeedbackAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
            return true;
        }

        //Add your methods here that directly connects to the dtabase
    }
}
