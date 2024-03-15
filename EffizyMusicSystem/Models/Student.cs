﻿using System;
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

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Instrument {  get; set; } = string.Empty;
        public string SkillLevel { get; set; } = string.Empty;
        public double Grades { get; set; }
        public bool TermsAndConditions {  get; set; }
        public int UserID {  get; set; }
    }
}
