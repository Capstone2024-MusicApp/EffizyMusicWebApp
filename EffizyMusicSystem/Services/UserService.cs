using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            return await _context.Users.FindAsync(userId);
        }


        // THIS METHOD IS TO GET THE SURRENT LOGGED IN USER ID
        //public int GetCurrentUserId()
        //{
        //    var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
        //    if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        //    {
        //        return userId;
        //    }
        //    Default user ID if not found
        //    return 0;
        //}

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
