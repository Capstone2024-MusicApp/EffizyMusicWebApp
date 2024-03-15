using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class RegistrationViewModel
    {
        public User User { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
        public List<UserType> UserTypes { get; set; }
    }
}
