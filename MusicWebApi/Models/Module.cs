namespace MusicWebApi.Models
{
    public class Module
    {
        public int Id { get; set; }

        public string ModuleName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
