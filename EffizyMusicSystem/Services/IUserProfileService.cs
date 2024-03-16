using EffizyMusicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public interface IUserProfileService
    {
        Task<User> GetUserById(int userId);
        Task<Student> GetStudentProfileAsync(int userId);
        Task<Instructor> GetInstructorProfileAsync(int userId);
        Task<bool> UpdateStudentProfileAsync(Student student);
        Task<bool> UpdateInstructorProfileAsync(Instructor instructor);
    }
}
