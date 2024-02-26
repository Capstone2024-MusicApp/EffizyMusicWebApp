using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string QuizTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
