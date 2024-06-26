﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EffizyMusicSystem.Models
{
    public class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int QuizId { get; set; }

        [JsonIgnore]
        public virtual Quiz? Quiz { get; set; } = null!;

        [NotMapped]
        public string AnswerValue { get; set; } = string.Empty;

        public virtual ICollection<QuestionChoice>? QuestionChoices { get; set; }

        public virtual ICollection<Answer>? Answers { get; set; }
    }
}
