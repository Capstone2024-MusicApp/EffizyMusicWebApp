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
        Task<bool> CreateStudentAsync(Student student);
        Task<bool> CreateInstructorAsync(Instructor instructor);
        Task<User> GetUserByIdAsync(int userTypeID);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> UpdateUserAsync(User user);
    }

}
