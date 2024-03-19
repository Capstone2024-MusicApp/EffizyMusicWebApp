using EffizyMusicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EffizyMusicSystem.Services
{
    public interface ICourseService
    {
            Task<List<Course>> GetCoursesAsync();
            Task<Course> GetCourseByIdAsync(int CourseID);
            Task AddCourseAsync(Course course);
            Task UpdateCourseAsync(Course course);
            Task DeleteCourseAsync(int CourseID);

            Task<List<Instrument>> GetInstrumentsAsync();
            Task<List<Instructor>> GetInstructorsAsync();
    }
}
