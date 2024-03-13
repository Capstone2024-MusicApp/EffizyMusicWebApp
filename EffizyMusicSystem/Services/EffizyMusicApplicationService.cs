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
        List<Instructor> GetInstructors();

        Task<bool> AddRating(InstructorRating rating);
    }
    public class EffizyMusicApplicationService : IEffizyMusicApplicationService
    {
        private readonly EffizyMusicContext _context;

        public EffizyMusicApplicationService(EffizyMusicContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public List<Lesson> GetLessons()
        {
            return _context.Lessons.ToList();
        }
        public List<Instructor> GetInstructors()
        {
            return _context.Instructors.ToList();
        }
        public async Task<bool> AddRating(InstructorRating rating)
        {
            if(rating == null)
            {
                return false; //Can Add exception
            }
            _context.InstructorRatings.Add(rating);
            await _context.SaveChangesAsync();
            return true;
        }

        //Add your methods here that directly connects to the dtabase
    }
}
