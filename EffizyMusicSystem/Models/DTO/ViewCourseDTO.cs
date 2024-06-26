﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models.DTO
{
    public class ViewCourseDTO
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CourseDescription { get; set; } = string.Empty;
        public string SkillLevel { get; set; } = string.Empty;
        public string EstimatedTime { get; set; } = string.Empty;
        public string Instrument { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public double InstructorRating { get; set; } = 0;

        public int enrollmentIDToSwitch { get; set; } = 0;
        [NotMapped]
        public virtual ICollection<Module>? Modules { get; set; }
        [NotMapped]
        public ICollection<SubscriptionPlan> Subscriptions { get; set; }
    }
}
