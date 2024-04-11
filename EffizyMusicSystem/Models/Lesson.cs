using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    
    public class Lesson
    {
        [Key]
        public int LessonNumber { get; set; }
        [Required(ErrorMessage = "Title is required"), MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        public string LessonMode { get; set; } = string.Empty;

        public int LessonOrder { get; set; } = 0;
        [Required(ErrorMessage = "Lesson Content video is required")]
        public byte[] LessonContent { get; set; } = new byte[0];
        public string LessonFileName { get; set; } = string.Empty;
        public virtual Module Module { get; set; }
    }
}
