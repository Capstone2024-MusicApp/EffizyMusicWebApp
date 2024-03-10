using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicWebApi.Models
{
    public class Instructor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int InstructorID { get; set; }
        public string Location { get; set; }
        public string HighestMusicQualification { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public string ReferenceEmail { get; set; }
        public string ReferencePhone { get; set; }
        public int UserID { get; set; }
    }
}
