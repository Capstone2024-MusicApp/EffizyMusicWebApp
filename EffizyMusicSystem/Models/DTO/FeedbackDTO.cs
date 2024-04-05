using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models.DTO
{
    public class FeedbackDTO
    {
        public int FeedbackID { get; set; }

        public string? Comments { get; set; }

        public DateTime FeedbackDate { get; set; }

        public int UserID { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }
    }
}
