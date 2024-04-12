using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required(ErrorMessage = "Please enter a course title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a course code.")]
        [StringLength(30, ErrorMessage = "Course code cannot exceed 30 characters.")]
        public string CourseCode { get; set; } = string.Empty;
       
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "Please select an instrument.")]
        [Display(Name = "Instrument")]
        public int InstrumentID { get; set; }

        [Required(ErrorMessage = "Please select an instructor.")]
        //[Display(Name = "Instructor")]
        public int InstructorID { get; set; }

        [Required(ErrorMessage = "Please select a skill level.")]
        [StringLength(30)]
        public string SkillLevel { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an estimated time for this course.")]
        [StringLength(30)]
        public string EstimatedTime { get; set; } = string.Empty;

        public Instrument Instrument { get; set; }

        [Required(ErrorMessage = "Please select an instructor.")]
        public Instructor Instructor { get; set; }

        public virtual ICollection<Module> Modules { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<SubscriptionPlan> Subscriptions { get; set; }

    }
}
