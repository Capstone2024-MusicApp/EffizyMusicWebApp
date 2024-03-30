using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    [NotMapped]
    public class ResultsViewModel
    {
        public string QuestionText { get; set; } = string.Empty;

        public string AnswerChoosed { get; set; } = string.Empty;

        public string CorrectChoice { get; set; } = string.Empty;
    }
}
