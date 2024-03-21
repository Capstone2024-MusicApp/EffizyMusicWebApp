using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models.DTO
{
    public class StudentCourseDTO
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }

        public required string Title { get; set; }

        public required string CourseDescription { get; set; }
        public required string CourseCode { get; set; }
        public int StudentID { get; set;}

        public required string ProgressStatus { get; set; }

        [NotMapped]
        public virtual ICollection<Module>? Modules { get; set; }


    }
}
