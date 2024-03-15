using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int StudentID { get; set; }
        public int InstructorID { get; set; }
        // [Required (ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        // [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        //[Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }

        // [Required(ErrorMessage = "Phone Number is required")]
        public string? Phone { get; set; }
        public string SkillLevel { get; set; }
        public double Grades { get; set; }
        public string PaymentPlan { get; set; }
        public bool TermsAndConditions {  get; set; }
        public int UserID {  get; set; }
        public int InstrumentID { get; set; }
        public User User { get; set; }
    }
}
