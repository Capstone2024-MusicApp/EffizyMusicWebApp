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
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [StringLength(30)]
        public string CourseCode { get; set; } = string.Empty;
       
        public string CourseDescription { get; set; }

        public int InstrumentID { get; set; }

        public int InstructorID { get; set; }
      
        [StringLength(30)]
        public string SkillLevel { get; set; } = string.Empty;
        [StringLength(30)]
        public string EstimatedTime { get; set; } = string.Empty;

        public Instrument Instrument { get; set; }

        public Instructor Instructor { get; set; }

        public virtual ICollection<Module> Modules { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<SubscriptionPlan> Subscriptions { get; set; }

    }
}
