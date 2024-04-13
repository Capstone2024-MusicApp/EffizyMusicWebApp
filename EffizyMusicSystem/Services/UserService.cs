using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class UserService : IUserService
    {
        private readonly EffizyMusicContext _context;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public UserService(EffizyMusicContext context, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .Include(x => x.UserType)
                .FirstOrDefaultAsync(x => x.UserID == userId);
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

        public async Task<int> GetCurrentUserId()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                var userIdClaim = user.FindFirst(c => c.Type == "sub");
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }
            }

            throw new InvalidOperationException("User is not authenticated or user ID claim not found.");
        }

        public async Task AddPaymentAsync(int userId, decimal amount)
        {
            var payment = new Payment
            {
                UserID = userId,
                Amount = (double)amount,
                PaymentDate = DateTime.UtcNow
            };

            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }
    }
}
