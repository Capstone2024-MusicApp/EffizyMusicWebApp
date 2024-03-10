using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Instructor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int InstructorID { get; set; }
        public string Location {  get; set; }
        public string HighestMusicQualification { get; set; } = string.Empty;
        public int YearsOfExperience {  get; set; }
        public string ReferenceEmail {  get; set; }
        public string ReferencePhone { get; set; }
        public int UserID {  get; set; }

        public User User { get; set; }


    }
}
