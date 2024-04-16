using EffizyMusicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EffizyMusicSystem.Services
{
    public interface ICourseService
    {
            Task<List<Course>> GetCoursesAsync();
            Task<Course> GetCourseByIdAsync(int CourseID);
            Task AddCourseAsync(Course course);
            Task UpdateCourseAsync(Course course);

            Task<List<Instrument>> GetInstrumentsAsync();
            Task<List<Instructor>> GetInstructorsAsync();
            Task<List<string>> GetDistinctSkillLevels();

            Task<List<Course>> GetCourseByInstructorAsync(int instructorId);
            Task<List<Course>> GetCourses(int instrumentID, string skillLevel);      
            Task<List<Course>> GetCoursesByInstrumentAndSkillLevel(int instrumentId, string skillLevel);
    }
}
