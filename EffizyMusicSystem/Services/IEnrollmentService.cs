using EffizyMusicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public interface IEnrollmentService
    {
        Task CompleteEnrollment(string paymentId, string studentId);
        Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId);
    }
}
