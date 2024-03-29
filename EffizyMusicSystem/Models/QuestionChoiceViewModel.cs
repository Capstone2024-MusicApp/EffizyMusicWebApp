﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EffizyMusicSystem.Enum;

namespace EffizyMusicSystem.Models
{
    [NotMapped]
    public class QuestionChoiceViewModel
    {
        public int QuizId { get; set; }

        [Required]
        [Display(Name = "Question Text:")]
        public string QuestionText { get; set; } = string.Empty;

        public string? ChoiceText { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Choice A:")]
        public string ChoiceText1 { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Choice B:")]
        public string ChoiceText2 { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Choice C:")]
        public string ChoiceText3 { get; set; } = string.Empty;

        //[Required]
        [Display(Name = "Choice D:")]
        public string? ChoiceText4 { get; set; }

        //[Required]
        [Display(Name = "Correct Choice")]
        public string? CorrectChoice { get; set; } = string.Empty;

        public Choices Choices { get; set; }

        public int QuestionId { get; set; }
    }
}
