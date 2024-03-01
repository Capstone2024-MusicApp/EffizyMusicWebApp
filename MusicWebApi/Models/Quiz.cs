using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicWebApi.Models
{
    public class Quiz
    {
        public int Id { get; set; }

        [Required]
        public string QuizTitle { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public int ModuleId { get; set; }

        [JsonIgnore]
        public virtual Module? Module { get; set; } = null!;

        public virtual ICollection<Question>? Questions { get; set; }
    }
}
