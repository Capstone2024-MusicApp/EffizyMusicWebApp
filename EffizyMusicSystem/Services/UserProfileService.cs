using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly EffizyMusicContext _context;

        public UserProfileService(EffizyMusicContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(u => u.UserID == userId);
        }

        public async Task<int?> GetStudentIDByUserIDAsync(int userId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.UserID == userId);
            return student?.StudentID;
        }

        public async Task<int?> GetInstructorIDByUserIDAsync(int userId)
        {
            var instructor = await _context.Instructors.FirstOrDefaultAsync(i => i.UserID == userId);
            return instructor?.InstructorID;
        }

        public async Task<Student> GetStudentProfileAsync(int userId)
        {
            return await _context.Students
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.UserID == userId);
        }

        public async Task<Instructor> GetInstructorProfileAsync(int userId)
        {
            return await _context.Instructors
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.UserID == userId);
        }

        public async Task<bool> UpdateStudentProfileAsync(Student student)
        {
            try
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateInstructorProfileAsync(Instructor instructor)
        {
            try
            {
                _context.Instructors.Update(instructor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}
