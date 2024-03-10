using System.ComponentModel.DataAnnotations;

namespace MusicWebApi.Models
{
    public class Lesson
    {
        [Key]
        public int LessonNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string LessonMode { get; set; } = string.Empty;
        public byte[] LessonContent { get; set; } = new byte[0];
        public virtual Module Module { get; set; }
    }
}
