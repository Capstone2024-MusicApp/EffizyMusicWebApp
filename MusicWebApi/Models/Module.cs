using System.ComponentModel.DataAnnotations;

namespace MusicWebApi.Models
{
    public class Module
    {
        //public int Id { get; set; }

        //public string ModuleName { get; set; } = string.Empty;

        //public string Description { get; set; } = string.Empty;

        [Key]
        public int ModuleID { get; set; }
        public string Title { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
