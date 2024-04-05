using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class QuizProgress
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizProgressID { get; set; }
        public int EnrollmentID { get; set; }

        public int QuizID { get; set; }

        public float Grade { get; set; }
    }
}
