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

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public string Location {  get; set; } = string.Empty;
        public string HighestMusicQualification { get; set; } = string.Empty;
        public int YearsOfExperience {  get; set; }
        public string ReferenceEmail {  get; set; } = string.Empty;
        public string ReferencePhone { get; set; } = string.Empty;
        public int UserID {  get; set; }


    }
}
