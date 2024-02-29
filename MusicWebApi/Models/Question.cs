using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicWebApi.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        //public string Description { get; set; } = string.Empty;

        public int QuizId { get; set; }

        [JsonIgnore]
        public virtual Quiz? Quiz { get; set; } = null!;

        public virtual ICollection<QuestionChoice>? QuestionChoices { get; set; }

        public virtual ICollection<Answer>? Answers { get; set; }
    }
}
