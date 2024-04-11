using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models.DTO
{
    public class QuestionnaireDTO
    {
        public int quizID { get; set; }

        public int questionID { get; set; }

        public required string questionText { get; set; }

        [NotMapped]
        public string selectedAnswer { get; set; }

        [NotMapped]
        public List<QuestionChoice> questionChoices { get; set; }

        [NotMapped]
        public List<Answer> answers { get; set; }
    }
}
