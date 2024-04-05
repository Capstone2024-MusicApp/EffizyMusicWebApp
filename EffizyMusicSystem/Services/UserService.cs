using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class UserService : IUserService
    {
        private readonly EffizyMusicContext _context;

        public UserService(EffizyMusicContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
 
                return false;
            }
        }

        public async Task<bool> CreateStudentAsync(Student student)
        {
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
 
                return false;
            }
        }

        public async Task<bool> CreateInstructorAsync(Instructor instructor)
        {
            try
            {
                _context.Instructors.Add(instructor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
 
                return false;
            }
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .Include(x => x.UserType)
                .FirstOrDefaultAsync(x => x.UserID == userId);
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task AddPaymentAsync(int userId, decimal amount)
        {
            var payment = new Payment
            {
                UserID = userId,
                Amount = (double)amount,
                PaymentDate = DateTime.UtcNow // or any date/time you prefer
            };

            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

      
    }


}
