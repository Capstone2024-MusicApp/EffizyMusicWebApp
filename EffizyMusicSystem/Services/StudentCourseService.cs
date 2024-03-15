using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using EffizyMusicSystem.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class StudentCourseService
    {
        private readonly EffizyMusicContext _context;

        public StudentCourseService(EffizyMusicContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetEnrolledCoursesAsync1(int studentID)
        {
            return await _context.Courses.FromSql($"select * from courses where CourseId in (select distinct CourseId from enrollments where StudentID = {studentID});").ToListAsync();
        }

        public async Task<List<StudentCourseDTO>> GetEnrolledCoursesAsync(int studentID)
        {
  
            return await _context.Database.SqlQuery<StudentCourseDTO>($"select e.EnrollmentID, c.CourseID, Title, CourseDescription, StudentID, ProgressStatus from courses c inner join enrollments e on c.CourseId = e.CourseID where StudentID = {studentID});").ToListAsync();
        }
    }

}
