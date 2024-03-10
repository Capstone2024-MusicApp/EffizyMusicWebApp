using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int StudentID { get; set; }

        public string Instrument {  get; set; }
        public string SkillLevel { get; set; }
        public double Grades { get; set; }
        public bool TermsAndConditions {  get; set; }
        public int UserID {  get; set; }

        public User User { get; set; }
    }
}
