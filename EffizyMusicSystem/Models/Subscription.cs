using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Subscription
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionID { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Amount { get; set; } = 0.00m;

        [Required]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        public Course Course { get; set; }
    }
}
