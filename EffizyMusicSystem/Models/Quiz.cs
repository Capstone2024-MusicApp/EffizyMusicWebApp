using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Quiz
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuizTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ModuleID { get; set; }

        [JsonIgnore]
        public virtual Module? Module { get; set; } = null!;

        public virtual ICollection<Question>? Questions { get; set; }

        [NotMapped]
        public float Grade { get; set; } = 0;
    }
}
