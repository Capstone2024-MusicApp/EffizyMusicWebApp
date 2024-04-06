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
        public string Title { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
