using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class InstructorRating
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingID { get; set; }

        public double Rating { get; set; }

        public string Feedback { get; set; } = string.Empty;

        public int InstructorID {  get; set; }
        public int UserID {  get; set; }
    }
}
