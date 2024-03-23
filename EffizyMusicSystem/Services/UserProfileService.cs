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

        public async Task<Student> GetStudentProfileAsync(int studentID)
        {
            try
            {
                var student = await _context.Students.FindAsync(studentID);
                return student;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting student profile: {ex.Message}");
                throw new Exception($"Error updating student profile: {ex.Message}");
            }
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

        public async Task<Instructor> GetInstructorProfileAsync(int instructorID)
        {
            try
            {
                var instructor =  await _context.Instructors.FindAsync(instructorID);
                return instructor;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting student profile: {ex.Message}");
                throw;
            }
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
