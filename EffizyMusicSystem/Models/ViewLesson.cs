using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class ViewLesson
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessonViewID { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public string LessonStatus { get; set; }

        public int LessonNumber { get;set; }

        public int UserID { get; set; }

    }
}
