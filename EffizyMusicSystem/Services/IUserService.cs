using EffizyMusicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int userId);
    }
}
