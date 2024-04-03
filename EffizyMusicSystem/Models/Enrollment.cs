using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace EffizyMusicSystem.Models
{
    public class Enrollment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int PaymentID { get; set; }

        public string EnrollmentStatus { get; set; }

        public required DateTime EnrollmentDate { get; set; }

        public  required string ProgressStatus { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
