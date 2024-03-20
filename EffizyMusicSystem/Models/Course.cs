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

        public string Title { get; set; }

        public string CourseCode { get; set; }

        public string CourseDescription { get; set; }

        public int InstrumentID { get; set; }

        public int InstructorID { get; set; }

        public string SkillLevel { get; set; }

        public string EstimatedTime { get; set; }

        public Instrument Instrument { get; set; }

        public Instructor Instructor { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
    }
}
