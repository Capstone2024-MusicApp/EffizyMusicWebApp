using EffizyMusicSystem.DAL;
using EffizyMusicSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public interface IEffizyMusicApplicationService
    {
        List<Lesson> GetLessons();
    }
    public class EffizyMusicApplicationService : IEffizyMusicApplicationService
    {
        private readonly EffizyMusicContext _context;

        internal EffizyMusicApplicationService(EffizyMusicContext context)
        {
            _context = context;
        }
        public List<Lesson> GetLessons()
        {
            return _context.Lessons.ToList();
        }

        //Add your methods here that directly connects to the dtabase

        public void AddCourse(Course entity)
        {
            try
            {
                _context.Courses.Add(entity);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Instrument> GetInstruments()
        {
            try
            {
                return _context.Instruments.ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Instructor> GetInstructors()
        {
            try
            {
                return _context.Instructors.ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Payment> GetPayments()
        {
            try
            {
                return _context.Payments.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
