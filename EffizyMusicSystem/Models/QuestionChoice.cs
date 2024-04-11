using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class QuestionChoice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ChoiceText { get; set; } = string.Empty;
        public int QuestionId { get; set; }

        public bool IsCorrectAnswer { get; set; }
        public virtual Question? Question { get; set; } = null!;
    }
}
