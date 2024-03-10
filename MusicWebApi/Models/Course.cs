using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace MusicWebApi.Models
{
    public class Course
    {
        [Key]
        [StringLength(10)]
        public int CourseID { get; set; }
        [StringLength(30)]

        public string Title { get; set; }

        [StringLength(30)]
        public string CourseMode { get; set; } = string.Empty;

        [StringLength(100)]
        public string CourseDescription { get; set; }

        public int InstrumentID { get; set; }
        public int InstructorID { get; set; }

        public Instrument Instrument { get; set; }

        public Instructor Instructor { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}
