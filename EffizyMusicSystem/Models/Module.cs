﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Module
    {
        [Key]
        public int ModuleID { get; set; }
        public string Title { get; set; }
        public string CourseID {  get; set; }
        
        public Course Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}