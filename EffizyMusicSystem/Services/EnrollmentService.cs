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
        public async Task UpdateEnrollment(int userId, int oldCourseId, int newCourseId)
        {
            try
            {
                var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.UserID == userId && e.CourseID == oldCourseId);
                if (enrollment != null)
                {
                    enrollment.CourseID = newCourseId;
                    _context.Entry(enrollment).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Enrollment not found for the given user ID and course ID.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update enrollment.", ex);
            }
        }

        public async Task<int> GetEnrolledCourseId(int userId)
        {
            try
            {
                var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.UserID == userId);
                if (enrollment != null)
                {
                    return enrollment.CourseID;
                }
                else
                {
                    throw new Exception("Enrollment not found for the given user ID.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve enrolled course ID.", ex);
            }
        }
        public async Task<Enrollment> GetEnrollmentByUserId(int userId)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(e => e.UserID == userId);

        }
    }
}
