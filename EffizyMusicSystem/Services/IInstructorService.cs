using EffizyMusicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public interface IInstructorService
    {
        Task<List<Instructor>> GetPendingInstructorsAsync();
        Task<bool> ApproveInstructorAsync(int instructorId);
        Task<bool> RejectInstructorAsync(int instructorId);
        Task<Instructor> GetInstructorByIdWithInstrumentAsync(int id);
        Task<Instructor> GetInstructorByUserIdAsync(int userId);

    }

}
