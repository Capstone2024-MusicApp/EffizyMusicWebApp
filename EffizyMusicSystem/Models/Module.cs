using System;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleID { get; set; }
        [Required(ErrorMessage = "Title is required"), MaxLength(255)]
        public string Title { get; set; }

        public int ModuleOrder { get; set; } = 0;

        public virtual Course Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }

    }
}
