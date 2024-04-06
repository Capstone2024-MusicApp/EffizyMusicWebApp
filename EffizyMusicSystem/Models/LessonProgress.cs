using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class LessonProgress
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessonProgressID { get; set; }
        public int EnrollmentID { get; set; }

        public int LessonID { get; set; }

        public required string ProgressStatus { get; set; }
    }
}
