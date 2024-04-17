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
            try
            {
                var instructor = await _context.Instructors.FindAsync(instructorId);
                if (instructor != null)
                {
                    instructor.Status = "approved";
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("Instructor not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to approve instructor.", ex);
            }
        }


        public async Task<bool> RejectInstructorAsync(int instructorId)
        {
            try
            {
                var instructor = await _context.Instructors.FindAsync(instructorId);
                if (instructor != null)
                {
                    instructor.Status = "Rejected";
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new InvalidOperationException("Instructor not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to reject instructor.", ex);
            }
        }

        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await _context.Instructors
                .Include(i => i.Instrument)
                .ToListAsync();
        }
    }
}
