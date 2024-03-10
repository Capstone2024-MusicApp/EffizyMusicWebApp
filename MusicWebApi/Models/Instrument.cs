using System.ComponentModel.DataAnnotations;

namespace MusicWebApi.Models
{
    public class Instrument
    {
        [Key]
        public int InstrumentID { get; set; }

        [StringLength(30)]
        public string InstrumentType { get; set; }
    }
}
