using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EffizyMusicSystem.Services
{
    public class CourseService : ICourseService
    {
        private readonly EffizyMusicContext _context;

        public CourseService(EffizyMusicContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int CourseID)
        {
            return await _context.Courses.FindAsync(CourseID);
        }

        public async Task AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Instrument>> GetInstrumentsAsync()
        {
            return await _context.Instruments.ToListAsync();
        }

        public async Task<List<Instructor>> GetInstructorsAsync()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<List<string>> GetDistinctSkillLevels()
        {
            return await _context.Courses
                .Select(c => c.SkillLevel)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<Course>> GetCourses(int instrumentID, string skillLevel)
        {
            return await _context.Courses
                .Where(c => c.InstrumentID == instrumentID && c.SkillLevel == skillLevel)
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesByInstrumentAndSkillLevel(int instrumentId, string skillLevel)
        {
            return await _context.Courses
                .Where(c => c.InstrumentID == instrumentId && c.SkillLevel == skillLevel)
                .ToListAsync();
        }

    }
}
