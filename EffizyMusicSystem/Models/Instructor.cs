using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Instructor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstructorID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string Phone { get; set; }

        public string Location { get; set; }
        public string HighestMusicQualification { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public string ReferenceEmail { get; set; }
        public string ReferencePhone { get; set; }
        public string Status { get; set; } = "pending";
        public int UserID { get; set; }
        public int InstrumentID { get; set; }
        public User User { get; set; }
        public Instrument Instrument { get; set; }

    }
}
