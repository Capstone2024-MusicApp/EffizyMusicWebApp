using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class QuizResult
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int QuizId { get; set; }

        public int QuestionId { get; set; }

        public string SelectedChoice { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
