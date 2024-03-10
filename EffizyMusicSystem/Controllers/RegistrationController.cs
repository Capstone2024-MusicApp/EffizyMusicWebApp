using EffizyMusicSystem.Models;
using EffizyMusicSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel;
using Microsoft.AspNetCore.Mvc;
using EffizyMusicSystem.DAL;


namespace EffizyMusicSystem.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly EffizyMusicContext _context;

        public RegistrationController(EffizyMusicContext context)
        {
            _context = context;
        }

        [HttpPost("student")]
        public IActionResult RegisterStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Save student logic
            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok("Student registered successfully");
        }

        [HttpPost("instructor")]
        public IActionResult RegisterInstructor(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Save instructor logic
            _context.Instructors.Add(instructor);
            _context.SaveChanges();

            return Ok("Instructor registered successfully");
        }
    }

}
