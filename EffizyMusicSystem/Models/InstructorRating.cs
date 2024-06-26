﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class InstructorRating
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingID { get; set; }


        [Required(ErrorMessage = "Rating is Required")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "Feedback is Required")]
        public string Feedback { get; set; }


        [Required(ErrorMessage = "Please select the Instructor")]
        public int InstructorID {  get; set; }
        public int UserID {  get; set; }
    }
}
