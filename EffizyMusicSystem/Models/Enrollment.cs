using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


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

        public int UserID { get; set; }

       // public string PayerID { get; set; }


        public Student Student { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }
        public Payment Payment { get; set; }
    }
}
