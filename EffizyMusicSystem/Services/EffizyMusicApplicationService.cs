using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
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
        Task<bool> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
    }

    public class EffizyMusicApplicationService : IEffizyMusicApplicationService
    {
        private readonly EffizyMusicContext _context;

        public EffizyMusicApplicationService(EffizyMusicContext context)
        {
            _context = context;
        }

        public List<Lesson> GetLessons()
        {
            return _context.Lessons.ToList();
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<UserType>> GetUserTypes()
    {
        return await _context.UserTypes.ToListAsync();
    }

        public async Task<User> GetUserByIdAsync(int userTypeID)
        {
            return await _context.Users
                .Include(x => x.UType)
                .FirstOrDefaultAsync(x => x.UserTypeID == userTypeID);
        }

        //Add other methods here that directly connect to the database
    }
}
