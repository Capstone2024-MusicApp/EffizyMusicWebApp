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
    public class EnrollmentService : IEnrollmentService
    {
        private readonly EffizyMusicContext _context;

        public EnrollmentService(EffizyMusicContext context)
        {
            _context = context;
        }

        public async Task CompleteEnrollment(string paymentId, string studentId)
        {
            // Find the enrollment based on paymentId and studentId
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.PaymentID.ToString() == paymentId && e.StudentID.ToString() == studentId);

            if (enrollment != null)
            {
                // Update the EnrollmentStatus to "Completed"
                enrollment.EnrollmentStatus = "Completed";
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Enrollment not found.");
            }
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int enrollmentId)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentID == enrollmentId);
        }
    }
}
