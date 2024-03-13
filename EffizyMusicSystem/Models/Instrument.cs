using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Models
{
    public class Instrument
    {
        [Key]
        public int InstrumentID { get; set; }

        [StringLength(30)]
        public string InstrumentType { get; set; }
    }
}
