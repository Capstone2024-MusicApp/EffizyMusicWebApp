using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly EffizyMusicContext _context;

        public InstructorService(EffizyMusicContext context)
        {
            _context = context;
        }

        public async Task<List<Instructor>> GetPendingInstructorsAsync()
        {
            return await _context.Instructors
                .Include(i => i.Instrument)
                .Where(i => i.Status == "Pending")
                .ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdWithInstrumentAsync(int id)
        {
            return await _context.Instructors
                .Include(i => i.Instrument)
                .FirstOrDefaultAsync(i => i.InstructorID == id);
        }

        public async Task<bool> ApproveInstructorAsync(int instructorId)
        {
            var instructor = await _context.Instructors.FindAsync(instructorId);
            if (instructor != null && instructor.User != null && instructor.User.UserType != null)
            {
                instructor.User.UType = await _context.UserTypes.FirstOrDefaultAsync(u => u.Description == "Instructor" && u.UserTypeID == 1); // Change to "Active" status
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RejectInstructorAsync(int instructorId)
        {
            var instructor = await _context.Instructors.FindAsync(instructorId);
            if (instructor != null && instructor.User != null && instructor.User.UserType != null)
            {
                instructor.User.UType = await _context.UserTypes.FirstOrDefaultAsync(u => u.Description == "Student" && u.UserTypeID == 1); // Change to "Student" status
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        
    }
}
