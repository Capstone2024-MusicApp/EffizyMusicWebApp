using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class UserTypeService
    {
        private readonly EffizyMusicContext _context;

        public UserTypeService(EffizyMusicContext context)
        {
            _context = context;
        }

        public async Task<List<UserType>> GetUserTypes()
        {
            return await _context.UserTypes.ToListAsync();
        }



        public async Task<List<UserType>> GetUsers()
        {
            var users = await this.GetUserTypes();
            return users;
        }

        
    }
}
