﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    [Table("Subscriptions")]
    public class SubscriptionPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionID { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Amount { get; set; } = 0.00m;

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid enrollment duration.")]
        public int EnrollmentDuration { get; set; }

        [Required]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        public Course Course { get; set; }
    }
}
